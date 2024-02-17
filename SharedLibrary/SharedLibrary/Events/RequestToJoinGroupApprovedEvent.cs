using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class RequestToJoinGroupApprovedEvent : IntegrationEvent
    {
        public RequestToJoinGroupApprovedEvent() : base(ExchangeName.RequestToJoinGroupApprovedEventExchange)
        {
        }

        public int GroupId { get; set; }
        public int ApproverId { get; set; }
        public int IdOfUserWhoJoinedTheGroup { get; set; }
    }
}
