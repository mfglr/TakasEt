
using Newtonsoft.Json;

namespace Application.Entities
{
	public class UserUserFollowing : Entity
	{
		public int FollowerId { get; private set; }
        public User Follower { get; }
        public int FollowingId { get; private set; }
		public User Followed { get; }

		public UserUserFollowing(int followerId, int followingId)
		{
			FollowerId = followerId;
			FollowingId = followingId;
		}
		
	}
}
