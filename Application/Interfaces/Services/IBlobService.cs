using Models.ValueObjects;

namespace Application.Interfaces.Services
{
	public interface IBlobService
	{
		Task UploadAsync(Stream stream, string blobName, ContainerName containerName, CancellationToken cancellationToken);
		Task<byte[]> DownloadAsync(string blobName, ContainerName containerName, CancellationToken cancellationToken);
	}
}
