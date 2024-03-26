using FileStock.Core.Configurations;
using FileStock.Core.Dtos;
using FileStock.Core.Services;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Exceptions;
using SharedLibrary.Helpers;
using SharedLibrary.ValueObjects;
using System.Net;

namespace FileStock.Service
{
    public class BlobService : IBlobService
	{

		private readonly IImageService _imageService;
		private readonly IContainerSettings _containerSettings;

        public BlobService(IImageService imageService, IContainerSettings containerSettings)
        {
            _imageService = imageService;
            _containerSettings = containerSettings;
        }

		private string GetPath(string containerName,string blobName)
		{
			return $"{_containerSettings.RootPath}/{containerName}/{blobName}";
        }

        public void Delete(string containerName, string blobName)
		{
			string path = GetPath(containerName, blobName);
			File.Delete(path);
		}

		private async Task<FileDto> SaveFileAsync(IFormFile file,string containerName,CancellationToken cancellationToken = default)
		{
            var extention = new string(Path.GetExtension(file.FileName).Except(new[] {'.'}).ToArray());
            if (string.IsNullOrEmpty(extention.Trim()))
                throw new AppException(
                    $"The extention of the file undefined : {file.FileName}",
                    HttpStatusCode.BadRequest
                );

            using var stream = file.OpenReadStream();
            if (stream == null || stream.Length == 0)
                throw new AppException("A stream is required", HttpStatusCode.BadRequest);

            var blobName = CreateUniqFileNameHelper.Run(extention);
            string path = GetPath(containerName, blobName);

            try
            {
                using var fileStream = File.Create(path);
                await stream.CopyToAsync(fileStream, cancellationToken);
                fileStream.Close();
            }
            catch (Exception ex)
            {
                Delete(containerName, blobName);
                throw new AppException($"{ex.Message}.\nUpload failed!", HttpStatusCode.InternalServerError);
            }

            return new FileDto()
            {
                ContainerName = containerName,
                BlobName = blobName,
                Extention = extention,
            };
        }
		private async Task<ImageFileDto> SaveImageFileAsync(IFormFile file, string containerName, CancellationToken cancellationToken = default)
		{
            var extention = Path.GetExtension(file.FileName);
            if (string.IsNullOrEmpty(extention.Trim()))
                throw new AppException(
					$"The extention of the file undefined : {file.FileName}", 
					HttpStatusCode.BadRequest
				);

            using var stream = file.OpenReadStream();
            if (stream == null || stream.Length == 0)
				throw new AppException("A stream is required", HttpStatusCode.BadRequest);

            var blobName = CreateUniqFileNameHelper.Run(extention);
            string path = GetPath(containerName, blobName);

			Dimension dimension;
            try
			{
				using var fileStream = File.Create(path);
                await stream.CopyToAsync(fileStream, cancellationToken);
                fileStream.Close();
                dimension = _imageService.GetDimension(stream);
            }
            catch (Exception ex)
			{
                Delete(containerName, blobName);
                throw new AppException($"{ex.Message}.\nUpload failed!", HttpStatusCode.InternalServerError);
            }

			return new ImageFileDto(){
				ContainerName = containerName,
				BlobName = blobName,
				Extention = extention,
				Height = dimension.Height,
				Width = dimension.Width,
			};
        }

        public async Task<FileDto> UploadFileAsync(IFormFile file,string containerName,CancellationToken cancellationToken = default)
        {
            return await UploadFileAsync(file, containerName, cancellationToken);
        }
        public async Task<List<FileDto>> UploadFileAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken = default)
        {
            if (files.Count == 0)
                throw new AppException("A file is required!", HttpStatusCode.BadRequest);

            var fileResponses = new List<FileDto>();
            try
            {
                foreach (var file in files)
                    fileResponses.Add(await SaveFileAsync(file, containerName, cancellationToken));
            }
            catch (Exception)
            {
                //if there is an error when uploading files, delete the uploaded files. All or none!
                foreach (var response in fileResponses)
                    Delete(containerName, response.BlobName);
                throw new AppException("There have been some issues while uploading files. Upload failed!", HttpStatusCode.BadRequest);
            }

            return fileResponses;
        }

        public async Task<ImageFileDto> UploadImageFileAsync(IFormFile file, string containerName,CancellationToken cancellationToken = default)
		{
            return await SaveImageFileAsync(file, containerName, cancellationToken);

        }
        public async Task<List<ImageFileDto>> UploadImageFilesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken = default)
        {
			if (files.Count == 0)
                throw new AppException("A file is required!",HttpStatusCode.BadRequest);
			
			var fileResponses = new List<ImageFileDto>();
			try
			{
                foreach (var file in files)
                    fileResponses.Add(await SaveImageFileAsync(file, containerName, cancellationToken));
            }
			catch (Exception)
			{
                //if there is an error when uploading files, delete the uploaded files before.
                //All or none!
                foreach (var response in fileResponses)
					Delete(containerName, response.BlobName);
				throw new AppException("There have been some issues while uploading files. Upload failed!", HttpStatusCode.BadRequest);
			}
            return fileResponses;
        }

        public async Task<byte[]> DownloadAsync(string containerName, string blobName, CancellationToken cancellationToken = default)
        {
            string path = GetPath(containerName, blobName);
            if (!File.Exists(path)) throw new AppException("The file was not found!", HttpStatusCode.NotFound);
            using var stream = File.OpenRead(path);
            var bytes = new byte[stream.Length];
            await stream.ReadAsync(bytes, 0, bytes.Length, cancellationToken);
            return bytes;
        }
    }	
}
