using Models.ValueObjects;

namespace Models.Entities
{
    public class Conversation : Entity, IAggregateRoot
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        protected Conversation(string title,string description)
        {
            Title = title;
            Description = description;
        }

        //Images
        public IReadOnlyCollection<ConversationImage> Images => _images;
        private readonly List<ConversationImage> _images = new();
        protected void AddImage(string blobName, string extention, Dimension dimension)
        {
            _images.Add(new ConversationImage(blobName, extention, dimension));
        }
        protected void RemoveImage(int id)
        {
            var image = _images.First(x => x.Id == id);
            image.Remove();
        }
        protected void DeleteImage(int id)
        {
			int index = _images.FindIndex(x => x.Id == id);
			_images.RemoveAt(index);
		}

        //Users
		public IReadOnlyCollection<ConversationUser> Users => _users;
		private readonly List<ConversationUser> _users = new();
		protected void AddUser(int userId)
        {
            _users.Add(new ConversationUser(Id, userId));
        }
        protected void DeleteUser(int userId)
        {
            int index = _users.FindIndex(x => x.UserId == userId);
            _users.RemoveAt(index);
        }
        
        //Messages
		public IReadOnlyCollection<Message> Messages => _messages;
		private readonly List<Message> _messages = new();
		public void AddMessage(int userId, string content)
        {
            _messages.Add(new Message(userId, content));
        }
		public void RemoveMessage(int id)
		{
			var message = _messages.First(m => m.Id == id);
			message.Remove();
		}
		public void DeleteMessage(int id)
        {
			var index = _messages.FindIndex(m => m.Id == id);
			_messages!.RemoveAt(index);
		}
        

    }
}
