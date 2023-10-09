namespace Application.Entities
{
	public class UserCommentLiking : Entity
	{
        public Guid UserId { get; private set; }
        public User User { get; }
        public Guid CommentId { get; private set; }
        public Comment Comment { get; }

		public UserCommentLiking(Guid userId, Guid commentId)
		{
			UserId = userId;
			CommentId = commentId;
		}
	}
}
