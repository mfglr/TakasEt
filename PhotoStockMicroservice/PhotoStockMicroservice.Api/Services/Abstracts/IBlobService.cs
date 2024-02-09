using SharedLibrary.Dtos;

namespace PhotoStockMicroservice.Api.Services.Abstracts
{
	public interface IBlobService
	{
        void CreateContainer(string containerName);
        void Delete(string containerName, string blobName);
        Task<ImageResponDto> UploadImageAsync(IFormFile file, string containerName, CancellationToken cancellationToken);
		Task<List<ImageResponDto>> UploadImagesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken);
		Task<byte[]> DownloadAsync(string containerName, string blobName, CancellationToken cancellationToken);
	}
}
