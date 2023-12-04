using Application.Interfaces.Services;
using System.Reflection;

namespace Service
{
	public class LocalBlobService : IBlobService
	{
		public async Task<Stream> DownloadAsync(string blobName, string containerName, CancellationToken cancellationToken)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			string path = $"{Path.GetDirectoryName(asm.Location)}/{containerName}/{blobName}"; ;
			return File.OpenRead(path);
			
		}

		public async Task UploadAsync(Stream stream, string blobName, string containerName, CancellationToken cancellationToken)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			string path = $"{Path.GetDirectoryName(asm.Location)}/{containerName}/{blobName}";
			using (FileStream fileStream = File.Create(path))
				await stream.CopyToAsync(fileStream, cancellationToken);
		}
	}
}
