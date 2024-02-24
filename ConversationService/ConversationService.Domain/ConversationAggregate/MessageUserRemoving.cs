namespace ConversationService.Domain.ConversationAggregate
{
    public class MessageUserRemoving
    {
        public Guid UserId { get; set; }
        public MessageUserRemoving(Guid userId)
        {
            UserId = userId;
        }
    }
}
