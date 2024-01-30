namespace Models.Entities
{
	public class Conversation : CrossEntity, IRemovableByManyUsers<ConversationUserRemoving>
	{
		public override int[] GetKey() => new[] { SenderId, ReceiverId };
		public int SenderId { get; private set; }
		public User Sender { get; }

		public int ReceiverId { get; private set; }
		public User Receiver { get; }

		public Conversation(int senderId,int receiverId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
		}

		//messages
		private readonly List<Message> _messages = new ();
		public IReadOnlyCollection<Message> Messages => _messages;
		public void AddMessage(int userId,string content)
		{
			_messages.Add(new Message(userId, content));
		}
		public void RemoveMessage(int messageId)
		{
			var message = _messages.First(x => x.Id == messageId);
			message.Remove();
		}
		public void RemoveMessageFromUser(int messageId,int userId)
		{
			var message = _messages.First(x => x.Id == messageId);
			message.RemoveFromUser(userId);
		}
		public void DeleteMessage(int messageId)
		{
			var index = _messages.FindIndex(x => x.Id == messageId);
			_messages.RemoveAt(index);
		}

		//IRemovableByManyUsers
		private readonly List<ConversationUserRemoving> _usersWhoRemoved = new ();
		public IReadOnlyCollection<ConversationUserRemoving> UsersWhoRemoved => _usersWhoRemoved;
		public void RemoveFromUser(int removerId)
		{
			_usersWhoRemoved.Add(new ConversationUserRemoving(SenderId, ReceiverId, removerId));
			foreach(var message in _messages)
				message.RemoveFromUser(removerId);
		}
	}
}
