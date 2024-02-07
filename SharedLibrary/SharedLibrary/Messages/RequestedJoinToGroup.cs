namespace SharedLibrary.Messages
{
    public class RequestedJoinToGroup
    {
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public List<int> AdminIds {  get; set; } 
    }
}
