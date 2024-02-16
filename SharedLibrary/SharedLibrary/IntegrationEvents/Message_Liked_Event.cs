using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class Message_Liked_Event : IntegrationEvent
    {
        public Message_Liked_Event() : base(Queue.Message_Liked_Queue)
        {
        }

        public int IdOfUserWhoLikedTheMessage { get; set; }
        public int IdOfMessageOwner { get; set; }
        public int MessageId { get; set; }
    }
}
