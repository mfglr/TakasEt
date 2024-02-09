namespace SharedLibrary.Events
{
    public class LikedMessageEvent
    {
        public int IdOfUserWhoLikedTheMessage { get; set; }
        public int IdOfMessageOwner { get; set; }
        public int MessageId { get; set; }
    }
}
