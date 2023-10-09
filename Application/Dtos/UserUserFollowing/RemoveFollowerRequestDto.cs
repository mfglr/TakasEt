namespace Application.Dtos
{
	public class RemoveFollowerRequestDto
	{
        public Guid FollowerId { get; private set; }

        public RemoveFollowerRequestDto(Guid followerId)
        {
            FollowerId = followerId;
        }
    }
}
