using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserRemoving : MessageUserCrossEntity
	{
		public MessageUserRemoving(int userId) : base(userId)
		{
		}
	}
}
