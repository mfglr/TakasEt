using ConversationService.Domain.ConversationAggregate;
using MediatR;

namespace ConversationService.Domain.DomainEvents
{
    public class ConversationCreatedDomainEvent : INotification
    {
        public Conversation Conversation { get; set; }
    }
}
