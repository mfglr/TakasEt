using MediatR;

namespace Application.Dtos
{
	public class IsPostLiked : IRequest<AppResponseDto>
	{
        public Guid PostId { get; private set; }

		public IsPostLiked(Guid postId)
		{
			PostId = postId;
		}
	}
}
