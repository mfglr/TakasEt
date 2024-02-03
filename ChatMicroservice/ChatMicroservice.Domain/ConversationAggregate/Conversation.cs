using ChatMicroservice.Domain.MessageEntity;
using SharedLibrary;
using SharedLibrary.Entities;

namespace ChatMicroservice.Domain.ConversationAggregate
{

	/*if a conversation has been created by a user then the receiver can't create the conversation between itself and the user. it means : 
                Conversation( senderId : 1, receiverId : 2 ) == Conversation( senderId : 2, receiverId : 1 )
        */
	public class Conversation : Entity, IRemovableByManyUsers<ConversationUserRemoving>, IAggregateRoot
	{
		public Guid SenderId { get; private set; }
		public Guid ReceiverId { get; private set; }

		public Conversation(Guid senderId,Guid receiverId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
		}

		//messages
		private readonly List<Message> _messages = new ();
		public IReadOnlyCollection<Message> Messages => _messages;

		private void throwExceptionIfIsNotOwnerId(Guid userId)
		{
			if (userId != SenderId && userId != ReceiverId) throw new Exception("error");
		}
		private Message getMessageOrThrowExceptionIfIsNotExist(Guid messageId)
		{
			var message = _messages.FirstOrDefault(x => x.Id == messageId);
			if (message == null) throw new Exception("error");
			return message;
		}
		
		public Message AddMessage(Guid userId,string content)
		{
			throwExceptionIfIsNotOwnerId(userId);

			var message = new Message(userId, content);
			message.SaveMessage();

			_messages.Add(message);
			return message;
		}
		public void RemoveMessage(Guid messageId)
		{
			getMessageOrThrowExceptionIfIsNotExist(messageId).Remove();
		}
		public void ReinsertMessage(Guid messageId)
		{
			getMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert();
		}
		public void RemoveMessageForUser(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Remove(userId);
		}
		public void ReinsertMessageForUser(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert(userId);
		}
		public void DeleteMessage(Guid messageId)
		{
			var message = getMessageOrThrowExceptionIfIsNotExist(messageId);
			_messages.Remove(message);
		}
		public void LikeMessage(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Like(userId);
		}
		public void DislikeMessage(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).Dislike(userId);
		}
		public bool IsLiked(Guid messageId, Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			return getMessageOrThrowExceptionIfIsNotExist(messageId).IsLiked(userId);
		}
		public void ViewMessage(Guid messageId,Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			getMessageOrThrowExceptionIfIsNotExist(messageId).View(userId);
		}
		public bool IsViewed(Guid messageId, Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			return getMessageOrThrowExceptionIfIsNotExist(messageId).IsViewed(userId);
		}

		//IRemovableByManyUsers
		private readonly List<ConversationUserRemoving> _usersWhoRemovedTheEntity = new ();
		public IReadOnlyCollection<ConversationUserRemoving> UsersWhoRemovedTheEntity => _usersWhoRemovedTheEntity;
		public void Remove(Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			_usersWhoRemovedTheEntity.Add(new ConversationUserRemoving(Id, userId));
			foreach(var message in _messages)
				message.Remove(userId);

		}
		public void Reinsert(Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			var index = _usersWhoRemovedTheEntity.FindIndex(x => x.UserId == userId);
			if(index == -1) throw new Exception("error");
			_usersWhoRemovedTheEntity.RemoveAt(index);
		}
		public bool IsRemovedByUser(Guid userId)
		{
			throwExceptionIfIsNotOwnerId(userId);
			return _usersWhoRemovedTheEntity.Any(x => x.UserId == userId);
		}
	}
}
