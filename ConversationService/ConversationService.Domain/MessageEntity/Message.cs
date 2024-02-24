using SharedLibrary.Entities;
using SharedLibrary.Extentions;

namespace ConversationService.Domain.MessageEntity
{
    public class Message : Entity<Guid>
    {
		public Guid ConversationId { get; private set; }

		public Guid SenderId { get; private set; }
		public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
		public int NumberOfImages { get; private set; }
		public MessageState MessageState { get; private set; }
        
		public Message(Guid senderId,string content)
        {
			SenderId = senderId;
            Content = content;
            NormalizeContent = content.CustomNormalize();
		}
		
		public void MarkAsSaved() => MessageState = MessageState.Saved;
		public void MarkAsReceived() => MessageState = MessageState.Received;
		public void MarkAsViewed() => MessageState = MessageState.Viewed;

	}
}
