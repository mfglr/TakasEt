using MediatR;

namespace Application.Dtos
{
    public class GetFollowedsByUserIdRequestDto : IRequest<AppResponseDto>
    {
        public Guid UserId { get; private set; }

        public GetFollowedsByUserIdRequestDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
