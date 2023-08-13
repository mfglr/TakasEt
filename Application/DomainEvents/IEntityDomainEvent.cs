using MediatR;

namespace Model.DomainEvents
{
	public interface IEntityDomainEvent
	{
		void AddDomainEvent(INotification domainEvent);
		void PublishAllDomainEvents(IPublisher publisher);
		void ClearAllDomainEvents();
	}
}
