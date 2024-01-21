namespace Application.Entities
{
	public class Comment : Entity
	{
		public int Id { get; private set; }
		public int? PostId { get; private set; }
		public int UserId { get; private set; }
		public string Content { get; private set; }
		public int? ParentId { get; private set; }

		public Post? Post { get; }
		public User User { get; }
		public Comment? Parent { get; }
		public IReadOnlyCollection<UserCommentLiking> UsersWhoLiked => _usersWhoLiked;
		public IReadOnlyCollection<Comment> Children => _children;

		private readonly List<UserCommentLiking> _usersWhoLiked = new();
		private readonly List<Comment> _children = new();

		public override int[] GetKey()
		{
			return new[] { Id };
		}

		public Comment(int? parentId, int? postId, int userId, string content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}


		//user comment liking
		public void LikeComment(int userId)
		{
			_usersWhoLiked.Add(new UserCommentLiking(userId, Id));
		}
		public void UnlikeComment(int userId)
		{
			var index = _usersWhoLiked.FindIndex(x => x.UserId == userId);
			_usersWhoLiked.RemoveAt(index);
		}

		//children
		public void AddChild(int userId,string content)
		{
			_children.Add(new Comment(Id,null,userId,content));
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
	}
}
