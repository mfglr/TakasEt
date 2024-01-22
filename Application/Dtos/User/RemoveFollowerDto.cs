using MediatR;

namespace Application.Dtos
{
	public class RemoveFollowerDto : IRequest<AppResponseDto>
	{
		public int? LoggedInUserId { get; private set; }
        public int? FollowerId { get; private set; }

		public RemoveFollowerDto(int? loggedInUserId, int? followerId)
		{
			LoggedInUserId = loggedInUserId;
			FollowerId = followerId;
		}


	}
}
