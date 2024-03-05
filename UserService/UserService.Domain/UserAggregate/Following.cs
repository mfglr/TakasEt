using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class Following : Entity<Guid>
    {
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }
        public Following(Guid followerId) => FollowerId = followerId;
    }
}
