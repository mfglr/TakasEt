namespace Application.Dtos.AppFile
{
	public class AppFileResponseDto : BaseResponseDto
	{
		public string BlobName { get; set; }
		public string ContainerName { get; set; }
		public string Extention { get; set; }
	}
}
