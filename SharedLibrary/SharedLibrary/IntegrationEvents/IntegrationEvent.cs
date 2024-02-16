using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public abstract class IntegrationEvent
    {
        public Queue Queue { get; private set; }
        protected IntegrationEvent(Queue queue) => Queue = queue;

    }
}
