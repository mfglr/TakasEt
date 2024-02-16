using SharedLibrary.ValueObjects;

namespace SharedLibrary.IntegrationEvents
{
    public class User_Followed_Event : IntegrationEvent
    {
        public User_Followed_Event() : base(Queue.User_Followed_Queue)
        {
        }

        public Guid FollowingId { get; set; }
        public Guid FollowerId { get; set; }
    }
}
