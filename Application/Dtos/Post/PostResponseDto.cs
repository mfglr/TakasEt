namespace Application.Dtos
{
	public class PostResponseDto : BaseResponseDto
	{
        public Guid UserId { get; set; }
        public string UserName {  get; set; }
		public string CategoryName { get; set; }
		public string Title { get;  set; }
        public string Content { get; set; }
        public DateTime PublishedDate { get; set; }
        public int CountOfImages { get; set; }
        public int CountOfLikes { get; set; }
		public int CountOfViews { get; set; }
		public int CountOfComments { get; set; }
	}
}
