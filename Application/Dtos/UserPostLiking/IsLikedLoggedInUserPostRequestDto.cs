using MediatR;

namespace Application.Dtos
{
	public class IsLikedLoggedInUserPostRequestDto : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public IsLikedLoggedInUserPostRequestDto(Guid postId)
		{
			PostId = postId;
		}
	}
}
