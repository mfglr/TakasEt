using MediatR;

namespace Application.Dtos
{
	public class IsPostLiked : IRequest<AppResponseDto>
	{
        public int PostId { get; private set; }

		public IsPostLiked(int postId)
		{
			PostId = postId;
		}
	}
}
