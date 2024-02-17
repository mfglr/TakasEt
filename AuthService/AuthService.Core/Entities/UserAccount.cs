using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Entities;
using SharedLibrary.Events;
using SharedLibrary.Services;

namespace AuthService.Core.Entities
{
    public class UserAccount : IdentityUser, IEntity<string>
    {
        public UserAccount(string email,string userName)
        {
            UserName = userName;
            Email = email;
        }

        //IEntity
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public void SetCreatedDate() => CreatedDate = DateTime.Now;
        public void SetUpdatedDate() => UpdatedDate = DateTime.Now;

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
        private readonly List<IntegrationEvent> events = new();
        public bool AnyIntegrationEvent() => events.Any();
        public void AddIntegrationEvent(IntegrationEvent @event) => events.Add(@event);
        public void ClearAllIntefrationEvents() => events.Clear();
        public void PublishAllIntegrationEvents(IIntegrationEventsPublisher publisher)
        {
            foreach (var @event in @events)
                publisher.Publish(@event);
        }
    }
}
