using MediatR;

namespace Application.Dtos
{
	public class LikeComment : IRequest<AppResponseDto>
	{
        public Guid CommentId { get; private set; }

		public LikeComment(Guid commentId)
		{
			CommentId = commentId;
		}
	}
}
