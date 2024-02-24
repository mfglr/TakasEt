namespace ConversationService.Domain.MessageEntity
{
	public class MessageUserLiking 
	{
		public Guid UserId { get; private set; }
		public MessageUserLiking(Guid userId)
		{
			UserId = userId;
		}
	}
}
