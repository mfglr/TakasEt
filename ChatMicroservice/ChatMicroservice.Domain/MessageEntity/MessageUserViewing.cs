using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserViewing : MessageUserCrossEntity
	{
		public MessageUserViewing(int userId) : base(userId)
		{
		}
	}
}
