namespace Application.Dtos
{
	public class CommentResponseDto : BaseResponseDto
	{
		public Guid ArticleId { get;  set; }
		public Guid UserId { get;  set; }
		public string Content { get;  set; }
		public int NumberOfLikes { get;  set; }
	}
}
