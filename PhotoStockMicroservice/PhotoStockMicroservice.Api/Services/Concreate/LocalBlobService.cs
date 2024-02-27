using PhotoStockMicroservice.Api.Configurations;
using PhotoStockMicroservice.Api.Services.Abstracts;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Helpers;
using SharedLibrary.ValueObjects;
using System.Net;

namespace PhotoStockMicroservice.Api.Services.Concreate
{
    public class LocalBlobService : IBlobService
	{

		private readonly IImageService _imageService;
		private readonly IContainerSettings _containerSettings;

        public LocalBlobService(IImageService imageService, IContainerSettings containerSettings)
        {
            _imageService = imageService;
            _containerSettings = containerSettings;
        }


		private string GetPath(string containerName)
		{
            return GetPathHelper.Run($"{_containerSettings.RootPath}/{containerName}");
        }
		private string GetPath(string containerName,string blobName)
		{
			return GetPathHelper.Run($"{_containerSettings.RootPath}/{containerName}/{blobName}");
        }

        public IAppResponseDto CreateContainer(string containerName)
        {
			var path = GetPath(containerName);
            if (Directory.Exists(path))
				throw new AppException($"The container ({containerName}) was already created!",HttpStatusCode.BadRequest);
			Directory.CreateDirectory(path);
			return new AppSuccessResponseDto();
        }

        public IAppResponseDto Delete(string containerName, string blobName)
		{
			string path = GetPath(containerName, blobName);
			File.Delete(path);
			return new AppSuccessResponseDto();
		}

		public async Task<byte[]> DownloadAsync(string containerName, string blobName,  CancellationToken cancellationToken)
		{
			string path = GetPath(containerName, blobName);
			if (!File.Exists(path)) throw new AppException("The file was not found!", HttpStatusCode.NotFound);
            using var stream = File.OpenRead(path);
			var bytes = new byte[stream.Length];
			await stream.ReadAsync(bytes,0,bytes.Length,cancellationToken);
			return bytes;
		}


		private async Task<ImageResponDto> SaveImageAsync(IFormFile file, string containerName, CancellationToken cancellationToken)
		{
            using var stream = file.OpenReadStream();
            if (stream == null || stream.Length == 0) throw new AppException("A stream is required", HttpStatusCode.BadRequest);

			var extention = Path.GetExtension(file.FileName);
			if(extention == null || extention == "")
				throw new AppException("The extention of file undefined",HttpStatusCode.BadRequest);

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
                throw new AppException($"{ex.Message}.\nUpload failed!", HttpStatusCode.BadRequest);
            }

			return new ImageResponDto(){
				ContainerName = containerName,
				BlobName = blobName,
				Extention = extention,
				Height = dimension.Height,
				Width = dimension.Width,
				AspectRatio = dimension.AspectRatio,
			};
        }

		public async Task<IAppResponseDto> UploadImageAsync(IFormFile file, string containerName,CancellationToken cancellationToken)
		{
            return new AppGenericSuccessResponseDto<ImageResponDto>(
				await SaveImageAsync(file, containerName, cancellationToken)
			);
		}

        public async Task<IAppResponseDto> UploadImagesAsync(IFormFileCollection files, string containerName, CancellationToken cancellationToken)
        {
			if (files.Count == 0) throw new Exception("A file is required!");
			
			var fileResponses = new List<ImageResponDto>();
			try
			{
                foreach (var file in files)
                    fileResponses.Add(await SaveImageAsync(file, containerName, cancellationToken));
            }
			catch (Exception)
			{
                //if there is an error when uploading files, delete the uploaded files. All or none!
                foreach (var response in fileResponses)
					Delete(containerName, response.BlobName);
				throw new AppException("There have been some issues while uploading files. Upload failed!", HttpStatusCode.BadRequest);
			}

            return new AppGenericSuccessResponseDto<List<ImageResponDto>>(fileResponses);
        }

        
    }	
}
