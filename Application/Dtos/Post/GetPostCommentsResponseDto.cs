namespace Application.Dtos
{
	public class GetPostCommentsResponseDto : BaseResponseDto
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public string SumaryOfContent { get; private set; }
		public int NumberOfLikes { get; private set; } = 0;
		public DateTime PublishedDate { get; private set; }
		public IReadOnlyCollection<CommentResponseDto> Comments { get; }
		public Guid CategoryId { get; private set; }
	}
}
