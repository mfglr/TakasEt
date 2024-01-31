using Models.Extentions;
using Models.ValueObjects;

namespace Models.Entities
{
	public class Message : Entity, ILikeable<MessageUserLiking,Message,User>, IViewable<MessageUserViewing,Message,User>, IRemovableByManyUsers<MessageUserRemoving,Message,User>
    {
        
        public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
		public MessageState MessageState { get; private set; }
		public IReadOnlyCollection<MessageImage> MessageImages { get; }
        
		public Message(int userId,string content)
        {
			UserId = userId;
            Content = content;
            NormalizeContent = content.CustomNormalize()!;
        }
		
		public void SaveMessage() => MessageState = MessageState.Saved;

		//Conversation
		public int? ConversationId { get; private set; }
		public Conversation? Conversation { get; }
		
		//Group
		public int? GroupId { get; private set; }
		public Group? Group { get; }

		//User
		public int UserId { get; private set; }
		public User User { get; }

		//IRemovableByManyUsers
		private readonly List<MessageUserRemoving> _usersWhoRemovedTheEntity = new ();
		public IReadOnlyCollection<MessageUserRemoving> UsersWhoRemovedTheEntity => _usersWhoRemovedTheEntity;
		public void RemoveTheEntityFromUser(int removerId)
		{
			_usersWhoRemovedTheEntity.Add(new MessageUserRemoving(Id, removerId));
		}
		public void AddAgainTheEntityToUser(int removerId)
		{
			var index = _usersWhoRemovedTheEntity.FindIndex(x => x.RemoverId == removerId);
			if (index == -1)
				throw new Exception("error");
			_usersWhoRemovedTheEntity.RemoveAt(index);
		}
		
		//ILikeable
		public IReadOnlyCollection<MessageUserLiking> UsersWhoLiked => _usersWhoLiked;
		private readonly List<MessageUserLiking> _usersWhoLiked;
		public void Like(int userId)
		{
			_usersWhoLiked.Add(new MessageUserLiking(Id, userId));
		}
		public void Dislike(int userId)
		{
			var index = _usersWhoLiked.FindIndex(x => x.UserId == userId);
			_usersWhoLiked.RemoveAt(index);
		}
		public bool IsLiked(int userId)
		{
			return _usersWhoLiked.Any(x => x.UserId == userId);
		}

		//IViewable
		public IReadOnlyCollection<MessageUserViewing> UsersWhoViewed => _usersWhoViewed;
		private readonly List<MessageUserViewing> _usersWhoViewed;
		public void View(int userId)
		{
			_usersWhoViewed.Add(new MessageUserViewing(Id, userId));
		}
		public bool IsViewed(int userId)
		{
			return _usersWhoViewed.Any(x => x.UserId == userId);
		}

	}
}
