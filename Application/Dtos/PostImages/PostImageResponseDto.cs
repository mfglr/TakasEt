namespace Application.Dtos.PostImages
{
	public class PostImageResponseDto : BaseResponseDto
	{
		public string BlobName { get; set; }
		public string ContainerName { get; set; }
		public string Extention { get; set; }
	}
}
