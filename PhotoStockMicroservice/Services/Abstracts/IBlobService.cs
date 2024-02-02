namespace PhotoStockMicroservice.Services.Abstracts
{
	public interface IBlobService
	{
		Task UploadAsync(Stream stream, string containerName, string blobName, CancellationToken cancellationToken);
		Task<byte[]> DownloadAsync(string containerName, string blobName, CancellationToken cancellationToken);
		void Delete(string containerName,string blobName);
	}
}
