using Application.Dtos.AppFile;

namespace Application.Dtos
{
	public class CommentResponseDto : BaseResponseDto
	{
		public int? PostId { get; set; }
        public int? ParentId { get; set; }
        public int UserId { get; set; }
		public string UserName { get; set; }
		public string Content { get; set; }
        public int CountOfChildren { get; set; }
		public int CountOfLikes {  get; set; }
		public AppFileResponseDto ProfileImage { get; set; }
    }
}
