using Application.Interfaces.Services;
using System.Text;

namespace Service
{
	public class FileWriterService : IFileWriterService
	{
		private MemoryStream _writer;
		private static int sizeOfInt = sizeof(int);
		private static byte[] systemInformations = new[] {
			(byte)sizeOfInt,
			(byte)(!BitConverter.IsLittleEndian ? 1 : 0)
		};

		public FileWriterService()
		{
			_writer = new MemoryStream();
		}

		public byte[] Bytes => _writer.ToArray();
		public async Task WriteFileAsync(byte[] file, string extention, CancellationToken cancellationToken)
		{
			var lengthOfFile = BitConverter.GetBytes(file.Length);
			var bytesOfExtention = Encoding.UTF8.GetBytes(extention);
			var lengthOfExtention = BitConverter.GetBytes(bytesOfExtention.Length);

			await _writer.WriteAsync(systemInformations);
			await _writer.WriteAsync(lengthOfExtention, cancellationToken);
			await _writer.WriteAsync(bytesOfExtention, cancellationToken);
			await _writer.WriteAsync(lengthOfFile, cancellationToken);
			await _writer.WriteAsync(file, cancellationToken);
		}
	}


}