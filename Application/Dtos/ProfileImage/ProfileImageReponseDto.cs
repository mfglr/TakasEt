namespace Application.Dtos.ProfileImage
{
	public class ProfileImageReponseDto : BaseResponseDto
	{
		public int UserId { get; set; }
		public string BlobName { get; set; }
		public string ContainerName { get; set} 
		public string Extention { get; set; }
	}
}
