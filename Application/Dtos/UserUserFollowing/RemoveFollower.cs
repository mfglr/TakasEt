using MediatR;

namespace Application.Dtos
{
	public class RemoveFollower : IRequest<AppResponseDto>
	{
		public int LoggedInUserId { get; set; }
        public int FollowerId { get; set; }
    }
}
