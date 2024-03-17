using AutoMapper;
using ConversationService.Application.Dtos;
using ConversationService.Application.Hubs;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkMessagesAsReceivedCommandHandler : IRequestHandler<MarkMessagesAsReceivedDto, IAppResponseDto>
    {

        private readonly IHttpContextAccessor _contextAccessor;
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public MarkMessagesAsReceivedCommandHandler(IHttpContextAccessor contextAccessor, AppDbContext context, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _contextAccessor = contextAccessor;
            _context = context;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IAppResponseDto> Handle(MarkMessagesAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            return await MarkMessagesAsReceivedAsync(request, loginUserId, cancellationToken);
        }

        private async Task<AppGenericSuccessResponseDto<List<MessageResponseDto>>> MarkMessagesAsReceivedAsync(
            MarkMessagesAsReceivedDto request, Guid userId, CancellationToken cancellationToken
            )
        {
            List<Message> messages;
            _context.ChangeTracker.Clear();
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
                return await MarkMessagesAsReceivedAsync(request, userId, cancellationToken);
            }


            return new AppGenericSuccessResponseDto<List<MessageResponseDto>>(
               _mapper.Map<List<MessageResponseDto>>(messages)
                );

        }
    }
}
