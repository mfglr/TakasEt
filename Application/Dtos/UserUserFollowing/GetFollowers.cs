using MediatR;

namespace Application.Dtos
{
    public class GetFollowers : IRequest<AppResponseDto>
    {
        public Guid UserId { get; private set; }
        public GetFollowers(Guid userId)
        {
            UserId = userId;
        }
    }
}
