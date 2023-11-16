using Application.Dtos;
using Application.Interfaces.Services;
using Azure.Storage.Blobs;

namespace Service
{
	public class AzureBlobService : IBlobService
	{
		private readonly BlobServiceClient _blobServiceClient;

		public AzureBlobService(BlobServiceClient blobServiceClient)
		{
			_blobServiceClient = blobServiceClient;
		}

		public async Task<byte[]> DownloadAsync(string blobName, string containerName, CancellationToken cancellationToken)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
			var result = await blobContainerClient.GetBlobClient(blobName).DownloadContentAsync(cancellationToken);
			return result.Value.Content.ToArray();
		}

		public async Task UploadAsync(Stream stream, string blobName, string containerName,CancellationToken cancellationToken)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
			await blobContainerClient.GetBlobClient(blobName).UploadAsync(stream, cancellationToken);
		}
	}
}
