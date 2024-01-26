namespace Models.Dtos
{
	public class PostResponseDto : BaseResponseDto
	{
        public int UserId { get; set; }
        public string UserName {  get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
		public string Title { get;  set; }
        public string Content { get; set; }
        public int CountOfImages { get; set; }
        public int CountOfLikes { get; set; }
		public int CountOfComments { get; set; }
		public bool LikeStatus { get; set; }
		public UserImageResponseDto? UserImage { get; set; }
		public IEnumerable<PostImageResponseDto> PostImages { get; set; }
		public IEnumerable<string> Tags { get; set; }
    }
}
