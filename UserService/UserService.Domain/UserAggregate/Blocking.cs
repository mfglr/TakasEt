using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class Blocking : Entity<Guid>
    {
        public Guid BlockerId { get; private set; }
        public Guid BlockedId { get; private set; }

        public Blocking(Guid blockerId) => BlockerId = blockerId;
    }
}
