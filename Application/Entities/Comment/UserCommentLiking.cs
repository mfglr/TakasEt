namespace Application.Entities
{
	public class UserCommentLiking : CrossEntity
	{
        public int UserId { get; private set; }
        public int CommentId { get; private set; }
		
		public User User { get; }
		public Comment Comment { get; }

		public override int[] GetKey()
		{
			return new[] { UserId, CommentId };
		}

		public UserCommentLiking(int userId, int commentId)
		{
			UserId = userId;
			CommentId = commentId;
		}

		
	}
}
