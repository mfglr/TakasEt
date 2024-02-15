using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class UserUserBlocking : Entity<Guid>
    {
        public Guid BlockerId { get; private set; }
        public Guid BlockedId { get; private set; }

        public UserUserBlocking(Guid blockerId) => BlockerId = blockerId;
    }
}
