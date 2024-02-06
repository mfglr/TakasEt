using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.ConversationAggregate
{
	public class ConversationUserRemoving : Entity
	{
		public int UserId { get; private set; }

		public ConversationUserRemoving(int userId)
		{
			UserId = userId;
		}

	}
}
