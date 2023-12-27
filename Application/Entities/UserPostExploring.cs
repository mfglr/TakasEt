namespace Application.Entities
{
	public class UserPostExploring : Entity
	{
        public int UserId { get; private set; }
        public User User { get; }
        public int PostId { get; private set; }
        public Post Post { get; }

        UserPostExploring(int userId, int postId)
        {
            UserId = userId;
            PostId = postId;
        }

    }
}
