using SharedLibrary.Entities;

namespace AuthService.Domain.UserAggregate
{
    public class UserUserViewing : Entity<string>
    {
        public string ViewerId { get; private set; }
        public string ViewedId { get; private set; }

        public UserUserViewing(string viewerId)
        {
            ViewerId = viewerId;
        }
    }
}
