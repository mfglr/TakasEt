
namespace ConversationService.Domain.MessageEntity
{
	public class MessageUserViewing
	{
		public Guid UserId { get; set; }
		public MessageUserViewing(Guid userId)
		{
			UserId = userId;
		}
	}
}
