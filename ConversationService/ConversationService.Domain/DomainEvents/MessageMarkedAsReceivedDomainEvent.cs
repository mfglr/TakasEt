using ConversationService.Domain.MessageAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class MessageMarkedAsReceivedDomainEvent : INotification
    {
        public Message Message { get; set; }
    }
}
