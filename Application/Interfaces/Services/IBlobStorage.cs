namespace Application.Interfaces.Services
{
	public interface IBlobStorage
	{

		string BlobUrl { get; }
		Task UploadAsync(Stream stream,string blobName,string containerName);
		Task<Stream> DownloadAsync(string name,string containerName);
		Task RemoveAsync(string name,string containerName);
		Task<List<string>> GetBlobNamesAsync(string containerName);
	}
}
