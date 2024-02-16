using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class RequestToJoinGroup_Approved_Event : IntegrationEvent
    {
        public RequestToJoinGroup_Approved_Event() : base(Queue.RequestToJoinGroup_Approved_Queue)
        {
        }

        public int GroupId { get; set; }
        public int ApproverId { get; set; }
        public int IdOfUserWhoJoinedTheGroup { get; set; }
    }
}
