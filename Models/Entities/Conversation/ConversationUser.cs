namespace Models.Entities
{
    public class ConversationUser : CrossEntity
    {
        public int ConversationId { get; private set; }
		public int UserId { get; private set; }

		public User User { get; }
        public Conversation Conversation { get; }

        public override int[] GetKey()
        {
            return new[] { ConversationId, UserId };
        }

        public ConversationUser(int conversationId, int userId)
        {
            ConversationId = conversationId;
			UserId = userId;
		}


	}
}
