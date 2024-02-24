using SharedLibrary.Entities;

namespace ConversationService.Domain.ConversationAggregate
{
    public class MessageUserLiking : Entity<Guid>
    {
        public Guid UserId { get; private set; }
        public MessageUserLiking(Guid userId)
        {
            UserId = userId;
        }
    }
}
