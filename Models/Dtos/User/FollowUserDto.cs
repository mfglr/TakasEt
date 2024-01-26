using MediatR;

namespace Models.Dtos
{
	public class FollowUserDto : IRequest<AppResponseDto>
    {
        public int LoggedInUserId { get; set; }
        public int FollowingId { get; private set; }

        public FollowUserDto(int followingId)
        {
			FollowingId = followingId;
        }
    }
}
