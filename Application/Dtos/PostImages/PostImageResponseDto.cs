using Application.Dtos.AppFile;

namespace Application.Dtos.PostImages
{
	public class PostImageResponseDto : AppFileResponseDto
	{
        public int PostId { get; set; }
		public int Index { get; set;}
    }
}
