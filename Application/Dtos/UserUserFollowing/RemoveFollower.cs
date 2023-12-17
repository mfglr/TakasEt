using MediatR;

namespace Application.Dtos
{
	public class RemoveFollower : IRequest<AppResponseDto>
	{
        public int FollowerId { get; set; }
    }
}
