namespace Models.Entities
{

	/*if a conversation has been created by a user then the receiver can't create the conversation between itself and the user. it means : 
                Conversation( senderId : 1, receiverId : 2 ) == Conversation( senderId : 2, receiverId : 1 )
        */
	public class Conversation : Entity, IRemovableByManyUsers<ConversationUserRemoving,Conversation,User>
	{
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
		public Message AddMessage(int userId,string content)
		{
			if (userId != SenderId && userId != ReceiverId)
				throw new Exception("error");
			var message = new Message(userId, content);
			message.SaveMessage();
			_messages.Add(message);
			return message;
		}
		public void RemoveMessage(int messageId)
		{
			var message = _messages.First(x => x.Id == messageId);
			message.Remove();
		}
		public void DeleteMessage(int messageId)
		{
			var index = _messages.FindIndex(x => x.Id == messageId);
			_messages.RemoveAt(index);
		}

		//IRemovableByManyUsers
		private readonly List<ConversationUserRemoving> _usersWhoRemovedTheEntity = new ();
		public IReadOnlyCollection<ConversationUserRemoving> UsersWhoRemovedTheEntity => _usersWhoRemovedTheEntity;
		public void RemoveTheEntityFromUser(int removerId)
		{
			if (removerId != SenderId && removerId != ReceiverId)
				throw new Exception("error");
			_usersWhoRemovedTheEntity.Add(new ConversationUserRemoving(Id, removerId));
			foreach(var message in _messages)
				message.RemoveTheEntityFromUser(removerId);
		}
		public void AddAgainTheEntityToUser(int removerId)
		{
			if (removerId != SenderId && removerId != ReceiverId)
				throw new Exception("error");
			var index = _usersWhoRemovedTheEntity.FindIndex(x => x.RemoverId == removerId);
			if(index == -1)
				throw new Exception("error");
			_usersWhoRemovedTheEntity.RemoveAt(index);
		}
	}
}
