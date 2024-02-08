namespace SharedLibrary.Messages
{
    public class ApprovedRequestToJoinGroupEvent
    {
        public int GroupId { get; set; }
        public int ApproverId { get; set; }
        public int IdOfUserWhoJoinedTheGroup { get; set; }
    }
}
