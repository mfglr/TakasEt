using ConversationService.Domain.MessageAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class MessagesMarkedAsViewedDomainEvent : INotification
    {
        public List<Message> Messages { get; set; }
    }
}
