using ConversationService.Application.Dtos;
using ConversationService.Domain.ConversationAggregate;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkAllNewMessagesAsReceivedCommandHandler : IRequestHandler<MarkAllNewMessagesAsReceivedDto, IAppResponseDto>
    {

        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IUnitOfWork _unitOfWork;


        public MarkAllNewMessagesAsReceivedCommandHandler(AppDbContext context, IHttpContextAccessor contextAccessor, IUnitOfWork unitOfWork)
        {
            _context = context;
            _contextAccessor = contextAccessor;
            _unitOfWork = unitOfWork;
        }

        public async Task<IAppResponseDto> Handle(MarkAllNewMessagesAsReceivedDto request, CancellationToken cancellationToken)
        {
            var loginUserId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);

            var conversations = await _context
                .Conversations
                .Include(x => x.Messages.Where(
                    x =>
                        x.MessageState.Status == MessageState.Created.Status &&
                        x.SenderId != loginUserId &&
                        x.CreatedDate < request.TimeStamp
                ))
                .Where(x => x.UserId1 == loginUserId || x.UserId2 == loginUserId)
                .ToListAsync(cancellationToken);

            foreach (var conversation in conversations)
                conversation.MarkMessagesAsReceived(loginUserId, request.ReceivedDate);

            await _unitOfWork.CommitAsync(cancellationToken);
            return new AppSuccessResponseDto();

        }
    }
}
