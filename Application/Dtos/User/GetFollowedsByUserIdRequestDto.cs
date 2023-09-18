using MediatR;

namespace Application.Dtos
{
	public class GetFollowedsByUserIdRequestDto : IRequest<AppResponseDto<IEnumerable<UserResponseDto>>>
	{
        public Guid FollowerId { get; set; }
    }
}
