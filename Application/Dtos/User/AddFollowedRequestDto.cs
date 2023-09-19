using MediatR;

namespace Application.Dtos.User
{
	public class AddFollowedRequestDto : IRequest<AppResponseDto>
	{
        public Guid FollowedId { get; private set; }

		public AddFollowedRequestDto(Guid followedId)
		{
			FollowedId = followedId;
		}
	}
}
