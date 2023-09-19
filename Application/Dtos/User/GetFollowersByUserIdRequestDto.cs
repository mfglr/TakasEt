using MediatR;

namespace Application.Dtos
{
	public class GetFollowersByUserIdRequestDto : IRequest<AppResponseDto>
	{
        public Guid FollowedId { get; set; }
    }
}
