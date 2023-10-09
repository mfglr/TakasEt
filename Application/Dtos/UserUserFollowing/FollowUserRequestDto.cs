using MediatR;

namespace Application.Dtos
{
    public class FollowUserRequestDto : IRequest<AppResponseDto>
    {
        public Guid FollowedId { get; private set; }

        public FollowUserRequestDto(Guid followedId)
        {
            FollowedId = followedId;
        }
    }
}
