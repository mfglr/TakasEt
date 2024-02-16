namespace SharedLibrary.Dtos
{
	public class ImageResponDto
	{
		public string ContainerName { get; set; } = null!;
		public string BlobName { get; set; } = null!;
        public string Extention { get; set; } = null!;
        public int Height { get; set; }
		public int Width { get; set; }
		public float AspectRatio { get; set; }
	}
}
