namespace Models.Entities
{
	public class MessageUserRemoving : CrossEntity
	{
		public override int[] GetKey() => new[] { MessageId, RemoverId }; 
		public int MessageId { get; private set; }
		public int RemoverId { get; private set; }

		public Message Message { get; }
		public User Remover { get; }

		public MessageUserRemoving(int messageId,int removerId)
		{
			MessageId = messageId;
			RemoverId = removerId;
		}

	}
}
