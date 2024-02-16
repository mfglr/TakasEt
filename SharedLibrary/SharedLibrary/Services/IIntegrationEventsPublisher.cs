using SharedLibrary.IntegrationEvents;

namespace SharedLibrary.Services
{
    public interface IIntegrationEventsPublisher : IDisposable
    {
        void Publish(IntegrationEvent @event);
    }
}
