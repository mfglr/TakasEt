using SharedLibrary.Entities;

namespace AuthService.Domain.UserAggregate
{
    public class UserUserBlocking : Entity<string>
    {
        public string BlockerId { get; private set; }
        public string BlockedId { get; private set; }

        public UserUserBlocking(string blockerId) => BlockerId = blockerId;
    }
}
