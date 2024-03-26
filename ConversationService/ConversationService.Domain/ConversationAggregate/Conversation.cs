using ConversationService.Domain.MessageAggregate;
using MediatR;
using SharedLibrary.Entities;

namespace ConversationService.Domain.ConversationAggregate
{

    public class Conversation : IEntity, IAggregateRoot
    {
        public Guid UserId1 { get; private set; }
        public Guid UserId2 { get; private set; }
        public DateTime DateOfLastDisplayedMessage1 { get; private set; }
        public DateTime DateOfLastDisplayedMessage2 { get; private set; }
        public byte[] RowVersion { get; private set; }

        public Conversation(Guid userId1,Guid userId2)
        {
            if (userId1 < userId2)
            {
                UserId1 = userId1;
                UserId2 = userId2;
            }
            else
            {
                UserId1 = userId2;
                UserId2 = userId1;
            }
        }
        private readonly List<Message> _messages = new();
        public IReadOnlyCollection<Message> Messages => _messages;
        public void AddMessage(Message message) {
            _messages.Add(message);
            if (message.SenderId == UserId1)
                if(message.SendDate > DateOfLastDisplayedMessage1)
                    DateOfLastDisplayedMessage1 = message.SendDate;
            else
                if(message.SendDate > DateOfLastDisplayedMessage2)
                    DateOfLastDisplayedMessage2 = message.SendDate;
        }
        public void MarkMessageAsReceived(Guid receiverId,string messageId,DateTime receivedDate)
        {
            var message = _messages.FirstOrDefault(x => x.Id == messageId);
            if(message != null)
            {
                message.MarkAsReceived(receiverId, receivedDate);
                if (receiverId == UserId1)
                    if(receivedDate > DateOfLastDisplayedMessage1)
                        DateOfLastDisplayedMessage1 = receivedDate;
                else
                    if(receivedDate > DateOfLastDisplayedMessage2)
                        DateOfLastDisplayedMessage2 = receivedDate;
            }
        }


        //IEntity
        public DateTime CreatedDate { get; protected set; }
        public DateTime? UpdatedDate { get; protected set; }
        public void SetCreatedDate() => CreatedDate = DateTime.UtcNow;
        public void SetUpdatedDate() => UpdatedDate = DateTime.UtcNow;
        //IRemovable
        public bool IsRemoved { get; protected set; }
        public DateTime? RemovedDate { get; protected set; }
        public virtual void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;
        }
        public virtual void Reinsert()
        {
            IsRemoved = false;
            RemovedDate = null;
        }
        //IDomainEventContainer
        private readonly List<INotification> _domainEvents = new();
        public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearAllDomainEvents() => _domainEvents.Clear();
        public bool AnyDomainEvents() => _domainEvents.Any();
        public async Task PublishAllDomainEventsAsync(IPublisher publisher, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in _domainEvents)
                await publisher.Publish(domainEvent, cancellationToken);
        }
        //IIntegrationEventsContainer
        private readonly List<object> @events = new();
        public IReadOnlyCollection<object> Events => @events;
        public bool AnyEvent() => @events.Any();
        public void AddEvent(object @event) => @events.Add(@event);
        public void ClearAllEvents() => events.Clear();
    }
}
