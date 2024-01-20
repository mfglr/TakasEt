using Application.Exceptions;

namespace Application.Entities
{
	public class Conversation : Entity
	{

        public string Title { get; protected set; }
        public IReadOnlyCollection<ConversationImage> ConversationImages => _conversationImages;
        public IReadOnlyCollection<UserConversation> UserConversations => _userConversations;
		public IReadOnlyCollection<Message> Messages => _messages;

		protected readonly List<ConversationImage> _conversationImages = new List<ConversationImage>();
		protected readonly List<UserConversation> _userConversations = new List<UserConversation>();
		protected readonly List<Message> _messages = new List<Message>();
       
		public void AddConversationImage(string blobName,string extention)
		{
			var newImage = new ConversationImage(Id, blobName, extention);
			newImage.Activate();
			_conversationImages.Add(newImage);
		}
		public void RemoveConversationImage(int id)
		{
			int index = _conversationImages.FindIndex(x => x.Id == id);
			if (index == -1) throw new ConversationImageNotFoundException();
			_conversationImages.RemoveAt(index);
		}
		public void ActivateConversationImage(int id)
		{
			var newActiveImage = _conversationImages.FirstOrDefault(x => x.Id == id);
			if (newActiveImage == null) throw new ConversationImageNotFoundException();

			var oldActiveImage = _conversationImages.FirstOrDefault(x => x.IsActive);
			if (oldActiveImage != null) oldActiveImage.Deactivate();

			newActiveImage.Activate();
		}
		public void DeleteConversationImage(int id)
		{
			var image = _conversationImages.FirstOrDefault(x => x.Id == id);
			if(image == null) throw new ConversationImageNotFoundException();

			image.Remove();
		}

		public void AddMessage(int userId, string content)
		{
			_messages.Add(new Message(userId, content));
		}
		public void DeleteMessage(int id)
		{
			var message = _messages.FirstOrDefault(m => m.Id == id);
			if (message == null) throw new MessageNotFoundException();
			message.Remove();
		}
		public void RemoveMessage(int id)
		{
			var index = _messages.FindIndex(m => m.Id == id);
			if (index == -1) throw new MessageNotFoundException();
			_messages.RemoveAt(index);
		}

    }
}
