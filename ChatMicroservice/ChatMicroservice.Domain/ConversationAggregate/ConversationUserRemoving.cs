using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.ConversationAggregate
{
	public class ConversationUserRemoving : Entity
	{
		public Guid UserId { get; private set; }

		public ConversationUserRemoving(Guid userId)
		{
			UserId = userId;
		}

	}
}
