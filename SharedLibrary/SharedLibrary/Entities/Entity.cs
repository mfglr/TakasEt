using MediatR;
using SharedLibrary.Events;

namespace SharedLibrary.Entities
{

    public abstract class Entity : Entity<int>
	{

	}

	public abstract class Entity<TKey> : IEntity<TKey>
	{
		public TKey Id { get; protected set; }
		public DateTime CreatedDate { get; protected set; }
		public DateTime? UpdatedDate { get; protected set; }

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
        private readonly List<object> @events = new();
		public IReadOnlyCollection<object> Events => @events;
        public bool AnyEvent() => @events.Any();
        public void AddEvent(object @event) => @events.Add(@event);
        public void ClearAllEvents() => events.Clear();
    }
}
