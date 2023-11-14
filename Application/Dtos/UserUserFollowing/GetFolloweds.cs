using MediatR;

namespace Application.Dtos
{
    public class GetFolloweds : IRequest<AppResponseDto>
    {
        public int UserId { get; private set; }

        public GetFolloweds(int userId)
        {
            UserId = userId;
        }
    }
}
