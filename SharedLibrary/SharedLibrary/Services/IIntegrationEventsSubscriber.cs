using RabbitMQ.Client.Events;
using SharedLibrary.ValueObjects;

namespace SharedLibrary.Services
{
    public interface IIntegrationEventsSubscriber : IDisposable
    {
        void Subscribe(Queue queue, Func<object, BasicDeliverEventArgs, Task> callback);
    }
}
