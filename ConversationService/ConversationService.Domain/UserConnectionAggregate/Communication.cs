using SharedLibrary.Entities;

namespace ConversationService.Domain.UserConnectionAggregate
{
    public class Communication : Entity<Guid>
    {
        public Guid SenderId { get; private set; }
        public Guid ReceiverId { get; private set; }
        public Communication(Guid senderId) => SenderId = senderId;
    }
}
