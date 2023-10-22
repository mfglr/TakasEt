namespace Application.Dtos
{
	public class CommentResponseDto : BaseResponseDto
	{
		public Guid? PostId { get; set; }
        public Guid? ParentId { get; set; }
        public Guid UserId { get; set; }
		public string UserName { get; set; }
		public string Content { get; set; }
        public int CountOfChildren { get; set; }
		public int CountOfLikes {  get; set; }
    }
}
