namespace Application.Entities
{
	public class Following : Entity
	{
		public Guid FollowerId { get; private set; }
        public User Follower { get; }
        public Guid FollowedId { get; private set; }
		public User Followed { get; }

		public Following(Guid followerId,Guid followedId)
		{
			FollowerId = followerId;
			FollowedId = followedId;
		}
	}
}
