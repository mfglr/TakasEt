namespace Models.Entities
{
	public class MessageUserLiking : CrossEntity
	{
		public override int[] GetKey() => new int[] { MessageId, UserId };
		public int MessageId { get; private set; }
		public int UserId { get; private set; }

		public Message Message { get; }
		public User User { get; }

		public MessageUserLiking(int messageId, int userId)
		{
			MessageId = messageId;
			UserId = userId;
		}

		
	}
}
