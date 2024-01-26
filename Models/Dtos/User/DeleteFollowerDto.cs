using MediatR;

namespace Models.Dtos
{
	public class DeleteFollowerDto : IRequest<AppResponseDto>
	{
		public int? LoggedInUserId { get; private set; }
        public int? FollowerId { get; private set; }

		public DeleteFollowerDto(int? loggedInUserId, int? followerId)
		{
			LoggedInUserId = loggedInUserId;
			FollowerId = followerId;
		}


	}
}
