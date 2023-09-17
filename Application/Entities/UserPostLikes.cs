namespace Application.Entities
{
	public class UserPostLikes : Entity
	{
        public Guid UserId { get; private set; }
        public User User { get;}
        public Guid PostId { get; private set; }
        public Post Post { get; }

		public UserPostLikes(Guid userId, Guid postId)
		{
			UserId = userId;
			PostId = postId;
		}
	}
}
