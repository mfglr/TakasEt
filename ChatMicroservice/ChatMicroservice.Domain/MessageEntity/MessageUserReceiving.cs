using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserReceiving : MessageUserCrossEntity
	{
		public MessageUserReceiving(Guid userId) : base(userId)
		{
		}

	}
}
