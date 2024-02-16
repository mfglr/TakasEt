using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class RequestToJoinToGroup_Created_Event : IntegrationEvent
    {
        public RequestToJoinToGroup_Created_Event() : base(Queue.RequestJoinToGroup_Created_Queue)
        {
        }

        public int IdOfUserWhoWantsToJoinGroup { get; set; }
        public int GroupId { get; set; }
        public List<int> AdminIds { get; set; } = null!;
    }
}
