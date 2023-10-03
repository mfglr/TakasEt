using Application.Interfaces.Services;
using System.Text;

namespace Service
{
	public class FileWriterService : IFileWriterService
	{

		private MemoryStream _writer;
		public byte[] Bytes => _writer.ToArray();

		public FileWriterService()
		{
			_writer = new MemoryStream();
		}

        public FileWriterService(MemoryStream writer)
        {
            _writer = writer;
        }

        private byte[] getIndex(int fileLength,string extention)
		{
			int offset = 0;
			var bytesOfFileLength = BitConverter.GetBytes(fileLength);
			var bytesOfExtention = Encoding.UTF8.GetBytes(extention);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytesOfFileLength);
				Array.Reverse(bytesOfExtention);

			}
			var ret = new byte[bytesOfFileLength.Length + bytesOfExtention.Length + 2];
			
			ret[offset] = (byte)bytesOfFileLength.Length;
			offset += 1;

			Buffer.BlockCopy(bytesOfFileLength, 0, ret, offset, bytesOfFileLength.Length);
			offset += bytesOfFileLength.Length;

			ret[bytesOfFileLength.Length + 1] = (byte)bytesOfExtention.Length;
			offset += 1;

			Buffer.BlockCopy(bytesOfExtention, 0, ret, offset, bytesOfExtention.Length);
			return ret;
		}

		public async Task WriteFileAsync(byte[] file,string extention,CancellationToken cancellationToken)
		{
			await _writer.WriteAsync(getIndex(file.Length,extention),cancellationToken);
			await _writer.WriteAsync(file);
		}
	}

	
}
