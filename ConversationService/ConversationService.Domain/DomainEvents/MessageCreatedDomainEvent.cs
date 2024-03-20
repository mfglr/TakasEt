using ConversationService.Domain.MessageAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class MessageCreatedDomainEvent : INotification
    {
        public Message Message { get; set; }
    }
}
