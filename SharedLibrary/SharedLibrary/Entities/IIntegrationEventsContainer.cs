using SharedLibrary.Events;
using SharedLibrary.Services;

namespace SharedLibrary.Entities
{
    public interface IIntegrationEventsContainer
    {
        bool AnyIntegrationEvent();
        public void ClearAllIntefrationEvents();
        void AddIntegrationEvent(IntegrationEvent @event);
        void PublishAllIntegrationEvents(IIntegrationEventsPublisher publisher);
    }
}
