using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserLiking : MessageUserCrossEntity
	{
		public MessageUserLiking(int userId) : base(userId)
		{
		}
	}
}
