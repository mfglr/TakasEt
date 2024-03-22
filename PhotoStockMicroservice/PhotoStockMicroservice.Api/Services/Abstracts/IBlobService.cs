﻿using SharedLibrary.Dtos;

namespace PhotoStockMicroservice.Api.Services.Abstracts
{
	public interface IBlobService
	{
        IAppResponseDto CreateContainer(string containerName);
        IAppResponseDto Delete(string containerName, string blobName);
        Task<IAppResponseDto> UploadImageAsync(IFormFile file, string containerName, CancellationToken cancellationToken = default);
		Task<IAppResponseDto> UploadImagesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken = default);
		Task<byte[]> DownloadAsync(string containerName, string blobName, CancellationToken cancellationToken = default);
	}
}
