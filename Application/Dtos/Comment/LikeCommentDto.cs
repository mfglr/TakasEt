using MediatR;

namespace Application.Dtos
{
	public class LikeCommentDto : IRequest<AppResponseDto>
	{
        public int CommentId { get; private set; }
		public int LoggedInUserId { get; private set; }

		public LikeCommentDto(int commentId, int loggedInUserId)
		{
			CommentId = commentId;
			LoggedInUserId = loggedInUserId;
		}
	}
}
