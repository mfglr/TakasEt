using MediatR;

namespace Application.DomainEvents
{
	public interface IEntityDomainEvent
	{
		void AddDomainEvent(INotification domainEvent);
		void PublishAllDomainEvents(IPublisher publisher);
		void ClearAllDomainEvents();
		bool AnyDomainEvents();
	}
}
