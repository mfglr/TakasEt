using ConversationService.Domain.ConversationAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class MessagesMarkedAsReceivedDomainEvent : INotification
    {
        public List<Message> Messages { get; set; }
    }
}
