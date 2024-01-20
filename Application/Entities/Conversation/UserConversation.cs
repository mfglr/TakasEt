namespace Application.Entities
{
	public class UserConversation : Entity
	{
        public int UserId { get; private set; }
        public int ConversationId { get; private set; }

        public User User { get; }
		public Conversation Conversation { get; }

        public UserConversation(int userId,int conversationId)
        {
            UserId = userId;
            ConversationId = conversationId;
        }
    }
}
