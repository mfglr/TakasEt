using SharedLibrary.Entities;

namespace ChatMicroservice.Core
{
	public abstract class MessageUserCrossEntity : Entity
	{
		public int UserId { get; protected set; }

		protected MessageUserCrossEntity(int userId)
		{
			UserId = userId;
		}
	}
}
