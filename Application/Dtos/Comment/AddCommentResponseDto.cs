namespace Application.Dtos
{
	public class AddCommentResponseDto
	{
		public Guid ArticleId { get; private set; }
		public Guid UserId { get; private set; }
		public string Content { get; private set; }
	}
}
