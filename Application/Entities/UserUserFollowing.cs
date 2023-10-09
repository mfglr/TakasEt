namespace Application.Entities
{
	public class UserUserFollowing : Entity
	{
		public Guid FollowerId { get; private set; }
        public User Follower { get; }
        public Guid FollowedId { get; private set; }
		public User Followed { get; }

		public UserUserFollowing(Guid followerId,Guid followedId)
		{
			FollowerId = followerId;
			FollowedId = followedId;
		}
	}
}
