
using Newtonsoft.Json;

namespace Application.Entities
{
	public class UserUserFollowing : Entity
	{
		public int FollowerId { get; private set; }
        public User Follower { get; }
        public int FollowedId { get; private set; }
		public User Followed { get; }

		public UserUserFollowing(int followerId, int followedId)
		{
			FollowerId = followerId;
			FollowedId = followedId;
		}

		[JsonConstructor]
		public UserUserFollowing(int followerId, int followedId,DateTime createdDate)
		{
			FollowerId = followerId;
			FollowedId = followedId;
			CreatedDate = createdDate;
		}
	}
}
