using MediatR;

namespace Application.Dtos
{
    public class UnfollowUserRequestDto : IRequest<AppResponseDto>
    {
        public Guid FollowedId { get; private set; }

        public UnfollowUserRequestDto(Guid followedId)
        {
            FollowedId = followedId;
        }
    }
}
