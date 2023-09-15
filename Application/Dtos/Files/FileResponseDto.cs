namespace Application.Dtos
{
	public class FileResponseDto : BaseResponseDto
	{
        public string BlobName { get; private set; }
		public string ContainerName { get; private set; }

		public FileResponseDto(string blobName, string containerName)
		{
			BlobName = blobName;
			ContainerName = containerName;
		}
	}
}
