using SharedLibrary.IntegrationEvents;
using SharedLibrary.Services;

namespace SharedLibrary.Entities
{
    public interface IIntegrationEventsContainer
    {
        bool AnyIntegrationEvent();
        void AddIntegrationEvent(IntegrationEvent @event);
        void PublishAllIntegrationEvents(IIntegrationEventsPublisher publisher);
    }
}
