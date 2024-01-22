
using Newtonsoft.Json;

namespace Application.Entities
{
	public class Following : CrossEntity
	{
		public int FollowerId { get; private set; }
        public int FollowingId { get; private set; }

		public User FollowerUser { get; }
		public User FollowingUser { get; }

		public override int[] GetKey()
		{
			return new[] { FollowerId, FollowingId };
		}

		public Following(int followerId, int followingId)
		{
			FollowerId = followerId;
			FollowingId = followingId;
		}

		
	}
}
