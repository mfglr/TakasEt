using Application.Interfaces.Services;
using System.Reflection;

namespace Service
{
	public class LocalBlobService : IBlobService
	{
		public async Task<byte[]> DownloadAsync(string blobName, string containerName, CancellationToken cancellationToken)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			string path = $"{Path.GetDirectoryName(asm.Location)}/{containerName}/{blobName}"; ;
			var stream = File.OpenRead(path);
			var bytes = new byte[stream.Length];
			await stream.ReadAsync(bytes,0,bytes.Length);
			return bytes;
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
