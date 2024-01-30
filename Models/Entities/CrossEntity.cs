using Models.DomainEventModels;
using MediatR;

namespace Models.Entities
{
    public abstract class CrossEntity : IBaseEntity, IEntityDomainEvent,IRemovable
    {

        //IBaseEntity
		public abstract int[] GetKey();
		public DateTime CreatedDate { get; protected set; }
        public DateTime? UpdatedDate { get; protected set; }
        public void SetCreatedDate(DateTime date)
        {
            CreatedDate = date;
        }
        public void SetUpdatedDate(DateTime date)
        {
            UpdatedDate = date;
        }

		//IEntityDomainEvent
		private readonly List<INotification> _domainEvents = new();
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

		//IRemovable
		public bool IsRemoved { get; protected set; }
		public DateTime? RemovedDate { get; protected set; }
		public void Remove()
		{
			IsRemoved = true;
			RemovedDate = DateTime.Now;
		}

	}
}
