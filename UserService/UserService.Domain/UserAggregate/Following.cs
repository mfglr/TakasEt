using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class Following : Entity<Guid>
    {
        public Guid FollowerId { get; private set; }
        public Guid FollowingId { get; private set; }
        public FollowingState State { get; private set; }

        public Following(Guid followerId) => FollowerId = followerId;

        public void MarkAsPending() => State = FollowingState.Pending;
        public void MarkAsRejected() => State = FollowingState.Rejected;

    }
}
