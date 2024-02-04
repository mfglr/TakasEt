using SharedLibrary.Entities;

namespace ChatMicroservice.Core
{
	public abstract class MessageUserCrossEntity : Entity
	{
		public Guid UserId { get; protected set; }

		protected MessageUserCrossEntity(Guid userId)
		{
			UserId = userId;
		}
	}
}
