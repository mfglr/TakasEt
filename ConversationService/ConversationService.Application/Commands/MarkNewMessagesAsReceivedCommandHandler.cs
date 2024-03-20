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
    public class MarkNewMessagesAsReceivedCommandHandler : IRequestHandler<MarkNewMessagesAsReceivedDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MarkNewMessagesAsReceivedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(MarkNewMessagesAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            return await MarkMessagesAsReceivedAsync(request, loginUserId, cancellationToken);
        }

        private async Task<AppSuccessResponseDto> MarkMessagesAsReceivedAsync(
            MarkNewMessagesAsReceivedDto request, Guid userId, CancellationToken cancellationToken
            )
        {
            List<Message> messages;
            messages = await _context
                .Messages
                .Include(x => x.Sender)
                .Where(x => request.Ids.Contains(x.Id))
                .ToListAsync(cancellationToken);

            foreach (var message in messages)
                message.MarkAsReceived(userId, request.ReceivedDate.ToDateTime());

            try
            {
                await _unitOfWork.CommitAsync(cancellationToken);
            }
            catch (DbUpdateConcurrencyException)
            {
                foreach (var message in messages)
                    message.ClearAllDomainEvents();
                _context.ChangeTracker.Clear();
                return await MarkMessagesAsReceivedAsync(request, userId, cancellationToken);
            }

            return new AppSuccessResponseDto();

        }
    }
}
