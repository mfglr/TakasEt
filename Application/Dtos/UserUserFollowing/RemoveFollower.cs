namespace Application.Dtos
{
	public class RemoveFollower
	{
        public Guid FollowerId { get; private set; }

        public RemoveFollower(Guid followerId)
        {
            FollowerId = followerId;
        }
    }
}
