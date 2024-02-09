namespace SharedLibrary.Events
{
    public class RequestedJoinToGroupEvent
    {
        public int IdOfUserWhoWantsToJoinGroup { get; set; }
        public int GroupId { get; set; }
        public List<int> AdminIds {  get; set; } 
    }
}
