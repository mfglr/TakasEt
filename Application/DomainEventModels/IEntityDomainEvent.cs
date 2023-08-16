using MediatR;

namespace Application.DomainEventModels
{
	public interface IEntityDomainEvent
	{
		void AddDomainEvent(INotification domainEvent);
		void PublishAllDomainEvents(IPublisher publisher);
		void ClearAllDomainEvents();
		bool AnyDomainEvents();
	}
}
