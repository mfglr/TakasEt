using MediatR;

namespace Application.Dtos
{
	public class FollowUser : IRequest<AppResponseDto>
    {
        public int FollowedId { get; private set; }

        public FollowUser(int followedId)
        {
            FollowedId = followedId;
        }
    }
}
