namespace Application.Entities
{
	public class UserPostViewing : Entity
	{
        public int UserId { get; private set; }
        public User User { get;}
        public int PostId { get; private set; }
        public Post Post { get; }

        public UserPostViewing(int userId, int postId)
		{
			UserId = userId;
			PostId = postId;
		}
	}
}
