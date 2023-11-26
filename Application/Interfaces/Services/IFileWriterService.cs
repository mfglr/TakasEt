using Application.Dtos;

namespace Application.Interfaces.Services
{
	public interface IFileWriterService
	{
		Task WriteFileAsync(byte[] file, string extention, CancellationToken cancellationToken);
		byte[] Bytes { get; }
	}

}