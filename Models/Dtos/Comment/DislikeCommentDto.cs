using MediatR;

namespace Models.Dtos
{
	public class DislikeCommentDto : IRequest<AppResponseDto>
	{
        public int? CommentId { get; private set; }
		public int? LoggedInUserId { get; private set; }

		public DislikeCommentDto(int? commentId, int? loggedInUserId)
		{
			CommentId = commentId;
			LoggedInUserId = loggedInUserId;
		}
	}
}
