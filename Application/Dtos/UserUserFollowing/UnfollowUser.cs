using MediatR;

namespace Application.Dtos
{
    public class UnfollowUser : IRequest<AppResponseDto>
    {
        public Guid FollowedId { get; private set; }

        public UnfollowUser(Guid followedId)
        {
            FollowedId = followedId;
        }
    }
}
