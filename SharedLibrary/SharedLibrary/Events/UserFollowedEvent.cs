using SharedLibrary.ValueObjects;

namespace SharedLibrary.Events
{
    public class UserFollowedEvent : IntegrationEvent
    {
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }

        public UserFollowedEvent(Guid followerId, Guid followingId) : base(ExchangeName.UserFollowedEventExchange)
        {
            FollowerId = followerId;
            FollowingId = followingId;
        }

    }
}
