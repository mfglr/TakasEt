using MediatR;

namespace Application.Dtos.User
{
	public class RemoveFollowedRequestDto : IRequest<AppResponseDto>
	{
        public Guid FollowedId { get; private set; }

		public RemoveFollowedRequestDto(Guid followedId)
		{
			FollowedId = followedId;
		}
	}
}
