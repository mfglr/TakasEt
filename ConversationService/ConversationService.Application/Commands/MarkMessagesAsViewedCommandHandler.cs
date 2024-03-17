using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkMessagesAsViewedCommandHandler : IRequestHandler<MarkMessagesAsViewedDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MarkMessagesAsViewedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(MarkMessagesAsViewedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            return await MarkMessagesAsViewedAsync(request, loginUserId, cancellationToken);
        }

        private async Task<AppGenericSuccessResponseDto<List<MessageResponseDto>>> MarkMessagesAsViewedAsync(
            MarkMessagesAsViewedDto request,Guid userId, CancellationToken cancellationToken
            )
        {
            List<Message> messages;
            _context.ChangeTracker.Clear();
            messages = await _context.Messages
                .Where(x => request.Ids.Contains(x.Id))
                .ToListAsync(cancellationToken);

            foreach (var message in messages)
                message.MarkAsViewed(userId, request.ViewedDate.ToDateTime());

            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach (var message in messages)
                    message.ClearAllDomainEvents();
                return await MarkMessagesAsViewedAsync(request, userId, cancellationToken);
            }

            return new AppGenericSuccessResponseDto<List<MessageResponseDto>>(
                _mapper.Map<List<MessageResponseDto>>(messages)
                );
        }

    }
}
