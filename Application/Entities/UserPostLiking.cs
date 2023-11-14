namespace Application.Entities
{
	public class UserPostLiking : Entity
	{
        public int UserId { get; private set; }
        public User User { get;}
        public int PostId { get; private set; }
        public Post Post { get; }

		public UserPostLiking(int userId, int postId)
		{
			UserId = userId;
			PostId = postId;
		}
	}
}
