using SharedLibrary.Entities;

namespace AuthService.Core.Entities
{
    public class Blocking : Entity<string>
    {
        public string BlockerId { get; private set; }
        public string BlockedId { get; private set; }

        public Blocking(string blockerId,string blockedId)
        {
            Id = Guid.NewGuid().ToString();
            BlockerId = blockerId;
            BlockedId = blockedId;
        }
    }
}
