using MediatR;

namespace Application.Dtos
{
	public class IsLikedLoggedInUserThePost : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public IsLikedLoggedInUserThePost(Guid postId)
		{
			PostId = postId;
		}
	}
}
