namespace ChatMicroservice.Application.Dtos
{
	public class MessageImageRequestDto
	{
		public string BlobName { get; set; }
		public string Extention { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
	}
}
