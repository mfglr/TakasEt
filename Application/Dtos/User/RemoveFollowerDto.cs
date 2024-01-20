using MediatR;

namespace Application.Dtos
{
	public class RemoveFollowerDto : IRequest<AppResponseDto>
	{
		public int LoggedInUserId { get; set; }
        public int FollowerId { get; set; }
    }
}
