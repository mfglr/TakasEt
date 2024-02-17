using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class RequestToFollowUserApprovedEvent : IntegrationEvent
    {
        public RequestToFollowUserApprovedEvent() : base(ExchangeName.RequestToFollowUserApprovedEventExchange)
        {
        }

        public Guid RequesterId { get; set; }
        public Guid RequestedId { get; set; }
    }
}
