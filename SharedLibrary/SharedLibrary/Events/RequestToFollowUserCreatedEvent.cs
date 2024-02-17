using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class RequestToFollowUserCreatedEvent : IntegrationEvent
    {
        public Guid RequestedId { get; private set; }
        public Guid RequesterId { get; private set; }

        public RequestToFollowUserCreatedEvent(Guid requesterId, Guid requestedId) : base(ExchangeName.RequestToFollowUserCreatedEventExchange)
        {
            RequesterId = requesterId;
            RequestedId = requestedId;
        }

    }
}
