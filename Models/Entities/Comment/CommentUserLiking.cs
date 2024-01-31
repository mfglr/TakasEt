namespace Models.Entities
{
    public class CommentUserLiking : CrossEntity<Comment,User>
    {
		public override int[] GetKey() => new[] { CommentId, UserId };
		public int CommentId { get; private set; }
		public int UserId { get; private set; }

		public Comment Comment { get; }
		public User User { get; }
        
        public CommentUserLiking(int commentId, int userId)
        {
            CommentId = commentId;
			UserId = userId;
		}
	}
}
