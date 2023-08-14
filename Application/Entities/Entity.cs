using Application.DomainEvents;
using MediatR;

namespace Application.Entities
{
    public abstract class Entity : IEntity, IEntityDomainEvent
	{
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

		public void SetId()
		{
			Id = Guid.NewGuid();
		}
		
		public void SetCreatedDate()
		{
			CreatedDate = DateTime.UtcNow;
		}

		public void SetUpdatedDate()
		{
			UpdatedDate = DateTime.UtcNow;
		}

		private List<INotification> _domainEvents = new List<INotification>();

        public void AddDomainEvent(INotification domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }
        
        public void PublishAllDomainEvents(IPublisher publisher)
        {
            _domainEvents.ForEach(
                domainEvent =>
                {
                    publisher.Publish(domainEvent);
                }
            );
        }

		public void ClearAllDomainEvents()
		{
			_domainEvents.Clear();
		}

		public bool AnyDomainEvents()
		{
			return _domainEvents.Any();
		}
	}
}
