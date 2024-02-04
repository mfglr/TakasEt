using ChatMicroservice.Core;

namespace ChatMicroservice.Domain.MessageEntity
{
	public class MessageUserLiking : MessageUserCrossEntity
	{
		public MessageUserLiking(Guid userId) : base(userId)
		{
		}
	}
}
