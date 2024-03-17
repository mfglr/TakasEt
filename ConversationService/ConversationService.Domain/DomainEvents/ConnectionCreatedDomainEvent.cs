using ConversationService.Domain.UserConnectionAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class ConnectionCreatedDomainEvent : INotification
    {
        public UserConnection UserConnection { get; set; }
    }
}
