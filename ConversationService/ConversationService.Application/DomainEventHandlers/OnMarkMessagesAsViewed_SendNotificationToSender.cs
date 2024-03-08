using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using ConversationService.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace ConversationService.Application.DomainEventHandlers
{
    public class OnMarkMessagesAsViewed_SendNotificationToSender : INotificationHandler<MessagesMarkedAsViewedDomainEvent>
    {

        private readonly IHubContext<ConversationHub> _conversationHub;
        private readonly AppDbContext _context;

        public OnMarkMessagesAsViewed_SendNotificationToSender(IHubContext<ConversationHub> conversationHub, AppDbContext context)
        {
            _conversationHub = conversationHub;
            _context = context;
        }

        public async Task Handle(MessagesMarkedAsViewedDomainEvent notification, CancellationToken cancellationToken)
        {
            var senderId = notification.Messages.Select(x => x.SenderId).First();
            var receiverId = notification.Messages.Select(x => x.ReceiverId).First();

            var sender = await _context.UserConnections.FirstOrDefaultAsync(x => x.Id == senderId,cancellationToken);

            if (sender != null && sender.IsConnected)
            {
                var data = new
                {
                    ReceiverId = receiverId,
                    Ids = notification.Messages.Select(x => x.Id)
                };

                await _conversationHub
                    .Clients
                    .Client(sender.ConnectionId)
                    .SendAsync("messagesViewedNotification", data, cancellationToken);
            }
                
                
        }
    }
}
