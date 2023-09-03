namespace Application.Dtos
{
	public class AddArticleResponseDto
	{
		public Guid UserId { get; private set; }
		public string Title { get; private set; }
		public string Content { get; private set; }
		public string SumaryOfContent { get; private set; }
		public Guid CategoryId { get; private set; }
	}
}
