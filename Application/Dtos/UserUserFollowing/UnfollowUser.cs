using MediatR;

namespace Application.Dtos
{
    public class UnfollowUser : IRequest<AppResponseDto>
    {
        public int FollowedId { get; private set; }

        public UnfollowUser(int followedId)
        {
            FollowedId = followedId;
        }
    }
}
