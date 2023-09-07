using Application.Entities;

namespace Application.Dtos
{
	public class CommentResponseDto : BaseResponseDto
	{
		public Guid ArticleId { get; private set; }
		public Guid UserId { get; private set; }
		public string Content { get; private set; }
		public int NumberOfLikes { get; private set; }
		public IReadOnlyCollection<Comment> Comments { get; }
	}
}
