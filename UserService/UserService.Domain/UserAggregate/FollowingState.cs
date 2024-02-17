using SharedLibrary.ValueObjects;

namespace UserService.Domain.UserAggregate
{
    public class FollowingState : ValueObject
    {

        public int Status { get; private set; }

        public static readonly FollowingState Pending = new () { Status = 0 };
        public static readonly FollowingState Rejected = new () { Status = 1 };

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Status;
        }
    }
}
