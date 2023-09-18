namespace Application.Dtos
{
	public class PostResponseDto : BaseResponseDto
	{
		public Guid UserId { get;  set; }
		public string Title { get;  set; }
		public string Content { get;  set; }
		public int CountOfLikes { get; set; }
		public int CountOfViews { get; set; }
		public Guid CategoryId { get;  set; }

	}
}
