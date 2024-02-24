using ConversationService.Domain.DomainEvents;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ConversationService.Application.DomainEventsHandlers
{
    public class OnConversationCreated_LetReceiverMessageWithSender_DomainEventHandler : INotificationHandler<ConversationCreatedDomainEvent>
    {

        private readonly AppDbContext _context;

        public OnConversationCreated_LetReceiverMessageWithSender_DomainEventHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ConversationCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            var sender = await _context
                .UserConnections
                .Include(x => x.UsersWhoCanSendMessageToTheUser.Where(x => x.Id == notification.Conversation.ReceiverId))
                .FirstOrDefaultAsync(x => x.Id == notification.Conversation.SenderId);
            
            if (sender == null || sender.UsersWhoCanSendMessageToTheUser.Any()) return;
            
            sender.AddSender(notification.Conversation.ReceiverId);
            
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
