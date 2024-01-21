namespace Application.Entities
{
	public class UserPostExploring : Entity
	{
        public int UserId { get; private set; }
        public int PostId { get; private set; }
		
        public User User { get; }
		public Post Post { get; }

		public override int[] GetKey()
		{
			return new int[] { UserId, PostId };
		}

		public UserPostExploring(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }

		
	}
}
