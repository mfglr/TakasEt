namespace Application.Entities
{
	public class Comment : RecursiveEntity<Comment>
	{
		public Guid? PostId { get; private set; }
		public Post? Post { get; }
		public Guid UserId { get; private set; }
		public User User { get; }
		public string Content { get; private set; }
		public IReadOnlyCollection<UserCommentLiking> UsersWhoLiked { get; }


		public Comment(Guid? parentId, Guid? postId, Guid userId, string content)
		{
			ParentId = parentId;
			PostId = postId;
			UserId = userId;
			Content = content;
		}

		
	}
}
