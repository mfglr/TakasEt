namespace Models.Entities
{
    public class PostUserExploring : CrossEntity<Post,User>
    {
		public override int[] GetKey() => new int[] { PostId, UserId };
		public int PostId { get; private set; }
		public int UserId { get; private set; }

		public Post Post { get; }
		public User User { get; }

        public PostUserExploring(int postId,int userId)
        {
            PostId = postId;
            UserId = userId;
        }

    }
}
