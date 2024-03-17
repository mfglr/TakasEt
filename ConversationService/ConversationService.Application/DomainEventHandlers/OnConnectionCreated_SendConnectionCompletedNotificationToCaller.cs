using ConversationService.Application.Hubs;
using ConversationService.Domain.DomainEvents;
using MediatR;
using Microsoft.AspNetCore.SignalR;

namespace ConversationService.Application.DomainEventHandlers
{
    public class OnConnectionCreated_SendConnectionCompletedNotificationToCaller : INotificationHandler<ConnectionCreatedDomainEvent>
    {
        private readonly IHubContext<MessageHub> _messageHub;

        public OnConnectionCreated_SendConnectionCompletedNotificationToCaller(IHubContext<MessageHub> messageHub)
        {
            _messageHub = messageHub;
        }

        public async Task Handle(ConnectionCreatedDomainEvent notification, CancellationToken cancellationToken)
        {
            await _messageHub
                .Clients
                .Client(notification.UserConnection.ConnectionId)
                .SendAsync("connectionCompletedNotification", cancellationToken);
        }
    }
}
