namespace Application.Dtos
{
	public class AddPostResponseDto
	{
		public string Title { get; private set; }
		public string Content { get; private set; }
		public Guid CategoryId { get; private set; }
	}
}
