namespace SharedLibrary.Dtos
{
	public class ImageResponDto
	{
		public string ContainerName { get; set; }
		public string BlobName { get; set; }
		public string Extention { get; set; }
		public int Height { get; set; }
		public int Width { get; set; }
		public float AspectRatio { get; set; }
	}
}
