using MediatR;

namespace Application.Dtos
{
    public class GetFolloweds : IRequest<AppResponseDto>
    {
        public Guid UserId { get; private set; }

        public GetFolloweds(Guid userId)
        {
            UserId = userId;
        }
    }
}
