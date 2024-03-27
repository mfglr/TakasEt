using ConversationService.Application.Dtos;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Application.Commands
{
    public class MarkMessageAsReceivedCommandHandler : IRequestHandler<MarkMessageAsReceivedDto,IAppResponseDto>
    {
        private readonly AppDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHttpContextAccessor _contextAccessor;

        public MarkMessageAsReceivedCommandHandler(AppDbContext context, IUnitOfWork unitOfWork, IHttpContextAccessor contextAccessor)
        {
            _context = context;
            _unitOfWork = unitOfWork;
            _contextAccessor = contextAccessor;
        }

        public async Task<IAppResponseDto> Handle(MarkMessageAsReceivedDto request, CancellationToken cancellationToken)
        {
            var receiverId = Guid.Parse(_contextAccessor.HttpContext.GetLoginUserId()!);
            var conversationKey = new List<Guid>() { receiverId, request.SenderId }
                .OrderBy(x => x)
                .ToList();
            return await MessageAsReceivedAsync(request, conversationKey, receiverId, cancellationToken);
        }

        private async Task<IAppResponseDto> MessageAsReceivedAsync(
            MarkMessageAsReceivedDto request, 
            List<Guid> conversationKey,
            Guid receiverId,
            CancellationToken cancellationToken
        )
        {
            var conversation = await _context
                .Conversations
                .Include(x => x.Messages.Where(x => x.Id == request.MessageId))
                .ThenInclude(x => x.Sender)
                .Where(x => x.UserId1 == conversationKey[0] && x.UserId2 == conversationKey[1])
                .FirstOrDefaultAsync(cancellationToken);

            if(conversation != null)
            {
                conversation.MarkMessageAsReceived(receiverId, request.MessageId, request.ReceivedDate);
                try
                {
                    await _unitOfWork.CommitAsync(cancellationToken);
                }
                catch (DbUpdateConcurrencyException)
                {
                    _context.ChangeTracker.Clear();
                    await MessageAsReceivedAsync(request, conversationKey, receiverId, cancellationToken);
                }
            }
            return new AppSuccessResponseDto();
        }

    }
}
