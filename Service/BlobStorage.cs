using Application.Configurations;
using Application.Interfaces.Services;
using Azure.Storage.Blobs;

namespace Service
{
	public class BlobStorage : IBlobStorage
	{

		private readonly BlobServiceClient _blobServiceClient;
        public BlobStorage(Local local)
        {
			_blobServiceClient = new BlobServiceClient(local.AzureStorage);
        }
        public string BlobUrl => throw new NotImplementedException();

		public Task<Stream> DownloadAsync(string name, string containerName)
		{
			throw new NotImplementedException();
		}

		public Task<List<string>> GetBlobNamesAsync(string containerName)
		{
			throw new NotImplementedException();
		}

		public Task RemoveAsync(string name, string containerName)
		{
			throw new NotImplementedException();
		}

		public async Task UploadAsync(Stream stream, string blobName, string containerName,CancellationToken cancellationToken)
		{
			var blobContainerClient = _blobServiceClient.GetBlobContainerClient(containerName);
			await blobContainerClient.CreateIfNotExistsAsync();
			await blobContainerClient.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.BlobContainer);
			await blobContainerClient.GetBlobClient(blobName).UploadAsync(stream, cancellationToken);
		}
	}
}
