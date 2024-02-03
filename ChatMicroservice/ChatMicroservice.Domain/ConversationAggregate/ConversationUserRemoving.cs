using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.ConversationAggregate
{
	public class ConversationUserRemoving : Entity
	{
		public Guid ConversationId { get; private set; }
		public Guid UserId { get; private set; }

		public ConversationUserRemoving(Guid conversationId, Guid userId)
		{
			ConversationId = conversationId;
			UserId = userId;
		}

	}
}
