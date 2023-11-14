using Newtonsoft.Json;

namespace Application.Entities
{
	public class Comment : Entity
	{
		public int? PostId { get; private set; }
		public Post? Post { get; }
		public int UserId { get; private set; }
		public User User { get; }
		public string Content { get; private set; }
		public int? ParentId { get; private set; }
		public Comment? Parent { get; }
		public IReadOnlyCollection<UserCommentLiking> UsersWhoLiked { get; }
		public IReadOnlyCollection<Comment> Children { get; }

		public Comment(int? parentId, int? postId, int userId, string content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}

		[JsonConstructor]
		public Comment(int? parentId, int? postId, int userId, string content,DateTime createdDate)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
			CreatedDate = createdDate;
		}
	}
}
