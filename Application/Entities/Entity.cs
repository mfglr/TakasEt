using Application.DomainEventModels;
using MediatR;

namespace Application.Entities
{
    public abstract class Entity : IEntity, IEntityDomainEvent, IRemovable
	{
		public int Id {  get; protected set; }
		public bool IsRemoved { get; protected set; }
		public DateTime CreatedDate { get; protected set; }
		public DateTime? UpdatedDate { get; protected set; }
		public DateTime? RemovedDate { get; protected set; }
		public int[] GetKey()
		{
			return new[] { Id };
		}
		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}
		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
		}
		public void Remove()
		{
			IsRemoved = true;
			RemovedDate = DateTime.Now;
		}

		private readonly List<INotification> _domainEvents = new ();
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
