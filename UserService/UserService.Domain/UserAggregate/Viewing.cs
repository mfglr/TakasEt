using SharedLibrary.Entities;

namespace UserService.Domain.UserAggregate
{
    public class Viewing : Entity<Guid>
    {
        public Guid ViewerId { get; private set; }
        public Guid ViewedId { get; private set; }

        public Viewing(Guid viewerId)
        {
            ViewerId = viewerId;
        }
    }
}
