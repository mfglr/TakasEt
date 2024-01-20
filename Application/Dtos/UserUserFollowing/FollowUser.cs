using MediatR;

namespace Application.Dtos
{
	public class FollowUser : IRequest<AppResponseDto>
    {
        public int LoggedInUserId { get; set; }
        public int FollowingId { get; private set; }

        public FollowUser(int followingId)
        {
			FollowingId = followingId;
        }
    }
}
