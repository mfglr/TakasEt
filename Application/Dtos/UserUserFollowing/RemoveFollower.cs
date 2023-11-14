namespace Application.Dtos
{
	public class RemoveFollower
	{
        public int FollowerId { get; private set; }

        public RemoveFollower(int followerId)
        {
            FollowerId = followerId;
        }
    }
}
