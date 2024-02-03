using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserArriving : MessageUserCrossEntity
	{
		public MessageUserArriving(Guid messageId, Guid userId) : base(messageId, userId)
		{
		}

	}
}
