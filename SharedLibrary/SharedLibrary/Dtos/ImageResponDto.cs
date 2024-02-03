namespace SharedLibrary.Dtos
{
	public class ImageResponDto : BaseResponseDto
	{
		public string BlobName { get; set; }
		public string Extention { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public float AspectRatio { get; set; }
	}
}
