using Models.Extentions;

namespace Models.Entities
{
	public class Message : Entity, ILikeable<MessageUserLiking>, IViewable<MessageUserViewing>
    {
        public int UserId { get; private set; }
        public int ConversationId { get; private set; }
        public string Content { get; private set; }
        public string NormalizeContent { get; private set; }
        public DateTime ArrivalDate { get; private set; }
        public DateTime ViewingDate { get; private set; }

		public Conversation Conversation { get; }
		public User User { get; }

        public Message(int userId, string content)
        {
            UserId = userId;
            Content = content;
            NormalizeContent = content.CustomNormalize()!;
        }

        public void ArrivaMessage()
        {
            ArrivalDate = DateTime.Now;
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
			ViewingDate = DateTime.Now;
		}
		public bool IsViewed(int userId)
		{
			return _usersWhoViewed.Any(x => x.UserId == userId);
		}
	}
}
