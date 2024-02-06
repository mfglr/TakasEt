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
		public int SenderId { get; private set; }
		public int ReceiverId { get; private set; }

		public Conversation(int senderId,int receiverId)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
		}

		//messages
		private readonly List<Message> _messages = new ();
		public IReadOnlyCollection<Message> Messages => _messages;

		private void ThrowExceptionIfIsNotOwnerId(int userId)
		{
			if (userId != SenderId && userId != ReceiverId) throw new Exception("error");
		}
		private Message GetMessageOrThrowExceptionIfIsNotExist(int messageId)
		{
			var message = _messages.FirstOrDefault(x => x.Id == messageId);
			return message ?? throw new Exception("error");
		}

		public Message AddMessage(int userId,string content)
		{
			ThrowExceptionIfIsNotOwnerId(userId);

			var message = new Message(userId, content);
			message.MarkAsSaved();

			_messages.Add(message);
			return message;
		}
		public void RemoveMessage(int messageId)
		{
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Remove();
		}
		public void ReinsertMessage(int messageId)
		{
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert();
		}
		public void RemoveMessageForUser(int messageId,int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Remove(userId);
		}
		public void ReinsertMessageForUser(int messageId,int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Reinsert(userId);
		}
		public void DeleteMessage(int messageId)
		{
			var message = GetMessageOrThrowExceptionIfIsNotExist(messageId);
			_messages.Remove(message);
		}
		public void LikeMessage(int messageId,int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Like(userId);
		}
		public void DislikeMessage(int messageId,int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).Dislike(userId);
		}
		public bool IsLiked(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			return GetMessageOrThrowExceptionIfIsNotExist(messageId).IsLiked(userId);
		}
		public void MarkAsReceived(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).MarkAsReceived(userId);
		}
		public bool IsReceivedBy(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			return GetMessageOrThrowExceptionIfIsNotExist(messageId).IsReceivedBy(userId);
		}
		public void ViewMessage(int messageId,int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			GetMessageOrThrowExceptionIfIsNotExist(messageId).View(userId);
		}
		public bool IsViewed(int messageId, int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			return GetMessageOrThrowExceptionIfIsNotExist(messageId).IsViewed(userId);
		}

		//IRemovableByManyUsers
		private readonly List<ConversationUserRemoving> _usersWhoRemovedTheEntity = new ();
		public IReadOnlyCollection<ConversationUserRemoving> UsersWhoRemovedTheEntity => _usersWhoRemovedTheEntity;
		public void Remove(int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			_usersWhoRemovedTheEntity.Add(new ConversationUserRemoving(userId));
			foreach(var message in _messages)
				message.Remove(userId);

		}
		public void Reinsert(int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			var index = _usersWhoRemovedTheEntity.FindIndex(x => x.UserId == userId);
			if(index == -1) throw new Exception("error");
			_usersWhoRemovedTheEntity.RemoveAt(index);
		}
		public bool IsRemovedByUser(int userId)
		{
			ThrowExceptionIfIsNotOwnerId(userId);
			return _usersWhoRemovedTheEntity.Any(x => x.UserId == userId);
		}
	}
}
