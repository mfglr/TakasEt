namespace Application.Dtos
{
	public class PostResponseDto : BaseResponseDto
	{
		public string UserName {  get; set; }
		public string CategoryName { get; set; }
		public string Title { get;  set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
