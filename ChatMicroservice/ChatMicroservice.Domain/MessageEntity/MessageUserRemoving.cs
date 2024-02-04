using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserRemoving : MessageUserCrossEntity
	{
		public MessageUserRemoving(Guid userId) : base(userId)
		{
		}
	}
}
