using MediatR;

namespace SharedLibrary.Entities.DomainEventModels
{
	public interface IDomainEventContainer
	{
		void AddDomainEvent(INotification domainEvent);
		Task PublishAllDomainEventsAsync(IPublisher publisher, CancellationToken cancellationToken);
		void ClearAllDomainEvents();
		bool AnyDomainEvents();
	}
}
