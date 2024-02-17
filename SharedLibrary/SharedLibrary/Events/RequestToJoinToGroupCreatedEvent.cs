using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class RequestToJoinToGroupCreatedEvent : IntegrationEvent
    {
        public RequestToJoinToGroupCreatedEvent() : base(ExchangeName.RequestToJoinToGroupCreatedEventExchange)
        {
        }

        public int IdOfUserWhoWantsToJoinGroup { get; set; }
        public int GroupId { get; set; }
        public List<int> AdminIds { get; set; } = null!;
    }
}
