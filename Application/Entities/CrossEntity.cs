using Application.DomainEventModels;
using MediatR;

namespace Application.Entities
{
	public abstract class CrossEntity : IBaseEntity,IEntityDomainEvent
	{
		public DateTime CreatedDate {  get; protected set; }
		public DateTime? UpdatedDate { get; protected set; }
		public abstract int[] GetKey();
		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}
		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
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
