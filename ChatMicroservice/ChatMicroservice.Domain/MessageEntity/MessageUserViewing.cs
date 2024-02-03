using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserViewing : MessageUserCrossEntity
	{
		public MessageUserViewing(Guid messageId, Guid userId) : base(messageId, userId)
		{
		}
	}
}
