namespace Models.Entities
{
    public class Following : CrossEntity
    {
		public override int[] GetKey() => new[] { FollowerId, FollowingId };
		public int FollowerId { get; private set; }
        public int FollowingId { get; private set; }

        public User FollowerUser { get; }
        public User FollowingUser { get; }


        public Following(int followerId, int followingId)
        {
            FollowerId = followerId;
            FollowingId = followingId;
        }


    }
}
