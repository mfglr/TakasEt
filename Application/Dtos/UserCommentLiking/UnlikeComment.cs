using MediatR;

namespace Application.Dtos
{
	public class UnlikeComment : IRequest<AppResponseDto>
	{
        public Guid CommentId { get; private set; }

		public UnlikeComment(Guid commentId)
		{
			CommentId = commentId;
		}
	}
}
