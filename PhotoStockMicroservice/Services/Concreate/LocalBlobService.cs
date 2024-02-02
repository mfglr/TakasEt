using PhotoStockMicroservice.Services.Abstracts;
using System.Reflection;

namespace PhotoStockMicroservice.Services.Concreate
{
	public class LocalBlobService : IBlobService
	{

		private string getPath(string containerName,string blobName)
		{
			Assembly asm = Assembly.GetExecutingAssembly();
			return $"{Path.GetDirectoryName(asm.Location)}/{containerName}/{blobName}";
		}

		public void Delete(string containerName, string blobName)
		{
			string path = getPath(containerName, blobName);
			if (!File.Exists(path)) throw new Exception("error");
			File.Delete(path);
		}

		public async Task<byte[]> DownloadAsync(string containerName, string blobName,  CancellationToken cancellationToken)
		{
			string path = getPath(containerName,blobName);

			var stream = File.OpenRead(path);
			var bytes = new byte[stream.Length];
			await stream.ReadAsync(bytes,0,bytes.Length,cancellationToken);
			return bytes;
		}

		public async Task UploadAsync(Stream stream, string containerName, string blobName,CancellationToken cancellationToken)
		{
			string path = getPath(containerName, blobName);

			using (FileStream fileStream = File.Create(path))
			await stream.CopyToAsync(fileStream, cancellationToken);
		}
	}	
}
