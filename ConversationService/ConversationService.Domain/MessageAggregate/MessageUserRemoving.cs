namespace ConversationService.Domain.MessageAggregate
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
