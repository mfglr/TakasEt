using SharedLibrary.Entities;

namespace ChatMicroservice.Core
{
	public abstract class MessageUserCrossEntity : Entity
	{
		public Guid MessageId { get; protected set; }
		public Guid UserId { get; protected set; }

		protected MessageUserCrossEntity(Guid messageId, Guid userId)
		{
			MessageId = messageId;
			UserId = userId;
		}
	}
}
