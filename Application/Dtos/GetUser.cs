using MediatR;

namespace Application.Dtos
{
	public class GetUser : IRequest<AppResponseDto>
	{
        public Guid UserId { get; private set; }
        public GetUser(Guid userId)
        {
            UserId = userId;
        }
    }
}
