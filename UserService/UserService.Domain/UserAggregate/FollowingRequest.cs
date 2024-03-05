using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class FollowingRequest : Entity<Guid>
    {
        public Guid RequesterId { get; private set; }
        public Guid RequestedId { get; private set; }
        public FollowingRequestState State { get; private set; }

        public FollowingRequest(Guid requesterId) => RequesterId = requesterId;
        public void MarkAsPending() => State = FollowingRequestState.Pending;
        public void MarkAsRejected() => State = FollowingRequestState.Rejected;
    }
}
