using MediatR;
using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public abstract class IntegrationEvent
    {
        public ExchangeName ExchangeName { get; set; }
        public IntegrationEvent() { }
        public IntegrationEvent(ExchangeName exchangeName) => ExchangeName = exchangeName;

    }
}
