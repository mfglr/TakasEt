namespace Models.Entities
{
	public class ConversationUserRemoving : CrossEntity<Conversation,User>
	{
		public override int[] GetKey() => new int[] { ConversationId, RemoverId };

		//Conversation
		public int ConversationId { get; private set; }
		public Conversation Conversation { get; }

		//User
		public int RemoverId { get; private set; }
		public User Remover { get; }

		public ConversationUserRemoving(int conversationId, int removerId)
		{
			ConversationId = conversationId;
			RemoverId = removerId;
		}

	}
}
