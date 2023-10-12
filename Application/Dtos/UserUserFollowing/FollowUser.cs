using MediatR;

namespace Application.Dtos
{
    public class FollowUser : IRequest<AppResponseDto>
    {
        public Guid FollowedId { get; private set; }

        public FollowUser(Guid followedId)
        {
            FollowedId = followedId;
        }
    }
}
