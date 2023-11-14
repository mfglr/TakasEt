using MediatR;

namespace Application.Dtos
{
    public class GetUser : IRequest<AppResponseDto>
    {
        public int UserId { get; private set; }
        public GetUser(int userId)
        {
            UserId = userId;
        }
    }
}
