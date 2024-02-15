using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class UserUserFollowing : Entity<Guid>
    {
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }

        public UserUserFollowing(Guid followerId) => FollowerId = followerId;
    }
}
