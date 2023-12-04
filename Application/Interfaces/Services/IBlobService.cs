namespace Application.Interfaces.Services
{
	public interface IBlobService
	{
		Task UploadAsync(Stream stream, string blobName, string containerName, CancellationToken cancellationToken);
		Task<Stream> DownloadAsync(string blobName, string containerName, CancellationToken cancellationToken);
	}
}
