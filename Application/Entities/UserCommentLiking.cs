namespace Application.Entities
{
	public class UserCommentLiking : Entity
	{
        public int UserId { get; private set; }
        public User User { get; }
        public int CommentId { get; private set; }
        public Comment Comment { get; }

		public UserCommentLiking(int userId, int commentId)
		{
			UserId = userId;
			CommentId = commentId;
		}
	}
}
