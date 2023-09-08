using Application.Entities;

namespace Application.Dtos
{
	public class ArticleResponseDto : BaseResponseDto
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public string SumaryOfContent { get; private set; }
		public int NumberOfLikes { get; private set; } = 0;
		public int NumberOfViews { get; private set; } = 0;
		public DateTime PublishedDate { get; private set; }
		public IReadOnlyCollection<CommentResponseDto> Comments { get; private set; }
		public Guid CategoryId { get; private set; }
	}
}
