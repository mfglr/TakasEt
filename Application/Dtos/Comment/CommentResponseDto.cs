namespace Application.Dtos
{
	public class CommentResponseDto : BaseResponseDto
	{
		public Guid PostId { get; set; }
		public Guid UserId { get; set; }
		public string Content { get; set; }
	}
}
