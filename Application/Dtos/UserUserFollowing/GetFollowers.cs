using MediatR;

namespace Application.Dtos
{
    public class GetFollowers : IRequest<AppResponseDto>
    {
        public int UserId { get; private set; }
        public GetFollowers(int userId)
        {
            UserId = userId;
        }
    }
}
