using MediatR;

namespace Application.Dtos.PostPostRequesting
{
	public class GetNonRequesterPostsOfLoggedInUserRequestDto : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public GetNonRequesterPostsOfLoggedInUserRequestDto(Guid postId)
		{
			PostId = postId;
		}
	}
}
