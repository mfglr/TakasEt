using SharedLibrary.Dtos;

namespace PhotoStockMicroservice.Api.Services.Abstracts
{
	public interface IBlobService
	{
        AppResponseDto CreateContainer(string containerName);
        AppResponseDto Delete(string containerName, string blobName);
        Task<AppResponseDto> UploadImageAsync(IFormFile file, string containerName, CancellationToken cancellationToken);
		Task<AppResponseDto> UploadImagesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken);
		Task<byte[]> DownloadAsync(string containerName, string blobName, CancellationToken cancellationToken);
	}
}
