using MediatR;

namespace Application.Dtos
{
	public class UnfollowUserDto : IRequest<AppResponseDto>
    {
        public int LoggedInUserId { get; private set; }
        public int FollowingId { get; private set; }

        public UnfollowUserDto(int followingId, int loggedInUserId)
        {
			FollowingId = followingId;
            LoggedInUserId = loggedInUserId;
        }
    }
}
