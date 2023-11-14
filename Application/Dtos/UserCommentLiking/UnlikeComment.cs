using MediatR;

namespace Application.Dtos
{
	public class UnlikeComment : IRequest<AppResponseDto>
	{
        public int CommentId { get; private set; }

		public UnlikeComment(int commentId)
		{
			CommentId = commentId;
		}
	}
}
