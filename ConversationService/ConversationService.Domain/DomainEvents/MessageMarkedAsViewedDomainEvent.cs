using ConversationService.Domain.MessageAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class MessageMarkedAsViewedDomainEvent : INotification
    {
        public Message Message { get; set; }
    }
}
