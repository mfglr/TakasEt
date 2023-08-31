using MediatR;

namespace Application.DomainEventModels
{
	public class EntityDomainEvent : IEntityDomainEvent
	{
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
