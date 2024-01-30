namespace Models.Entities
{
	public class ConversationUserRemoving : CrossEntity
	{
		public override int[] GetKey() => new int[] { SenderId, ReceiverId, RemoverId };

		//Conversation
		public int SenderId { get; private set; }
		public int ReceiverId { get; private set; }
		public Conversation Conversation { get; }

		//User
		public int RemoverId { get; private set; }
		public User Remover { get; }

		public ConversationUserRemoving(int senderId, int receiverId, int removerId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
			RemoverId = removerId;
		}

	}
}
