using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class UserUserViewing : Entity<Guid>
    {
        public Guid ViewerId { get; private set; }
        public Guid ViewedId { get; private set; }

        public UserUserViewing(Guid viewerId)
        {
            ViewerId = viewerId;
        }
    }
}
