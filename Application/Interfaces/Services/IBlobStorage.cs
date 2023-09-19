using System;

namespace Application.Interfaces.Services
{
	public interface IBlobStorage
	{
		Task UploadAsync(Stream stream, string blobName, string containerName, CancellationToken cancellationToken);
		Task<byte[]> DownloadAsync(string name, string containerName, CancellationToken cancellationToken);
		Task RemoveAsync(string name,string containerName);
		Task<List<string>> GetBlobNamesAsync(string containerName);
	}
}
