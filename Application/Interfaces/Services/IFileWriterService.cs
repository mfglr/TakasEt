namespace Application.Interfaces.Services
{
	public interface IFileWriterService
	{
		Task WriteFileAsync(byte[] file, string extention, CancellationToken cancellationToken);
		byte[] Bytes { get; }
	}
	public class BytesOfFile
	{
		public byte[] Bytes { get; private set; }
		public int Extention { get; private set; }

		public BytesOfFile(byte[] bytes, int extention)
		{
			Bytes = bytes;
			Extention = extention;
		}
	}



}
