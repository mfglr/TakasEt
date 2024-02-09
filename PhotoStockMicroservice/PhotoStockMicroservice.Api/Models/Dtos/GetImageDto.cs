namespace PhotoStockMicroservice.Api.Models.Dtos
{
	public class GetImageDto
	{
		public string ContainerName { get; private set; } 
		public string BlobName { get; private set; }

		public GetImageDto(string containerName, string blobName)
		{
			ContainerName = containerName;
			BlobName = blobName;
		}
	}
}
