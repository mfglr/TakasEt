namespace Models.Entities
{
	public class MessageUserViewing : CrossEntity
	{
		public override int[] GetKey() => new[] { MessageId, UserId };
		public int MessageId { get; private set; }
		public int UserId { get; private set; }

		public Message Message { get; }
		public User User { get; }

		public MessageUserViewing(int messageId, int userId)
		{
			MessageId = messageId;
			UserId = userId;
		}
		
	}
}
