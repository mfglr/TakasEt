using MediatR;

namespace Application.Dtos.User
{
	public class FollowUserRequestDto : IRequest<NoContentResponseDto>
	{
        public Guid FollowedId { get; private  set; }

		public FollowUserRequestDto(Guid followedId)
		{
			FollowedId = followedId;
		}
	}
}
