using MediatR;

namespace Application.Dtos
{
	public class GetFollowedsByUserIdRequestDto : IRequest<AppResponseDto>
	{
        public Guid FollowerId { get; set; }
    }
}
