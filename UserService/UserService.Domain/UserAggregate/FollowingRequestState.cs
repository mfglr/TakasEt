using SharedLibrary.ValueObjects;

namespace UserService.Domain.UserAggregate
{
    public class FollowingRequestState : ValueObject
    {

        public int Status { get; private set; }

        public static readonly FollowingRequestState Pending = new () { Status = 0 };
        public static readonly FollowingRequestState Rejected = new () { Status = 1 };

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Status;
        }
    }
}
