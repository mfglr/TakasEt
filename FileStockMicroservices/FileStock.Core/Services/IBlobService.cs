using FileStock.Core.Dtos;
using Microsoft.AspNetCore.Http;

namespace FileStock.Core.Services
{
    public interface IBlobService
    {
        void Delete(string containerName, string blobName);
        
        Task<FileDto> UploadFileAsync(IFormFile file, string containerName, CancellationToken cancellationToken = default);
        Task<List<FileDto>> UploadFileAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken = default);

        Task<ImageFileDto> UploadImageFileAsync(IFormFile file, string containerName, CancellationToken cancellationToken = default);
        Task<List<ImageFileDto>> UploadImageFilesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken = default);
        
        Task<byte[]> DownloadAsync(string containerName, string blobName, CancellationToken cancellationToken = default);
    }
}
