using MediatR;

namespace Application.Dtos
{
    public class GetFollowersByUserIdRequestDto : IRequest<AppResponseDto>
    {
        public Guid UserId { get; private set; }
        public GetFollowersByUserIdRequestDto(Guid userId)
        {
            UserId = userId;
        }
    }
}
