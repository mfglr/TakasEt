using Application.Dtos;

namespace Application.Interfaces.Services
{
	public interface IAppFileService
	{
		Task UploadAsync(UploadFilesRequestDto appFile, CancellationToken cancellationToken);
		Task UploadAsync(Stream stream, string blobName, string containerName, CancellationToken cancellationToken);
		Task<byte[]> DownloadAsync(string name, string containerName, CancellationToken cancellationToken);
	}
}
