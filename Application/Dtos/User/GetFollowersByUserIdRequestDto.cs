using MediatR;

namespace Application.Dtos
{
	public class GetFollowersByUserIdRequestDto : IRequest<AppResponseDto<IEnumerable<UserResponseDto>>>
	{
        public Guid FollowedId { get; set; }
    }
}
