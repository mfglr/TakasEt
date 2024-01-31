namespace Models.Entities
{
    public class Comment : Entity, IAggregateRoot, ILikeable<CommentUserLiking,Comment,User>
    {
        public int? PostId { get; private set; }
		public int? ParentId { get; private set; }
		public int UserId { get; private set; }
        public string Content { get; private set; }
        
        public Post? Post { get; }
		public Comment? Parent { get; }
		public User User { get; }
        
        public Comment(int? postId, int? parentId, int userId, string content)
        {
			PostId = postId;
			ParentId = parentId;
            UserId = userId;
            Content = content;
        }

		//children
		public IReadOnlyCollection<Comment> Children => _children;
		private readonly List<Comment> _children = new();
		public void AddChild(int userId, string content)
        {
            _children.Add(new Comment(Id, null, userId, content));
        }
        public void RemoveChild(int childCommentId)
        {
            var childComment = _children.FirstOrDefault(x => x.Id == childCommentId);
            childComment!.Remove();
        }
        public void DeleteChild(int childCommentId)
        {
            var index = _children.FindIndex(x => x.Id == childCommentId);
            _children.RemoveAt(index);
        }

		//ILikeable
		public IReadOnlyCollection<CommentUserLiking> UsersWhoLiked => _usersWhoLiked;
		private readonly List<CommentUserLiking> _usersWhoLiked = new();
		public void Like(int userId)
		{
			_usersWhoLiked.Add(new CommentUserLiking(userId, Id));
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
		
	}
}
