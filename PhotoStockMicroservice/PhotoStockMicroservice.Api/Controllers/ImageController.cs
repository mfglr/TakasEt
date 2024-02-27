using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PhotoStockMicroservice.Api.Services.Abstracts;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;

namespace PhotoStockMicroservice.Api.Controllers
{
    [Route("[controller]/[action]")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		private readonly IBlobService _blobService;

		public ImageController(IBlobService blobService)
		{
			_blobService = blobService;
		}

		[Authorize(Roles = "user")]
        [HttpGet("{containerName}/{blobName}")]
		public async Task<FileContentResult> DownloadImage(string containerName, string blobName,CancellationToken cancellationToken)
		{
			return File(
				await _blobService.DownloadAsync(containerName, blobName, cancellationToken),
				"application/octet-stream"
			);
		}

        [Authorize(Roles = "user")]
        [HttpPost]
		public async Task<IAppResponseDto> UploadImage([FromForm] IFormCollection form,CancellationToken cancellationToken)
		{
			var containerName = form.ReadString("containerName");
			if (containerName == null)
				throw new AppException("A container name is required!",HttpStatusCode.BadRequest);

			var file = form.Files.FirstOrDefault();
			if (file == null || file.Length == 0)
				throw new AppException("A file is required!", HttpStatusCode.BadRequest);

			return await _blobService.UploadImageAsync(file, containerName, cancellationToken);
		}

        [Authorize(Roles = "user")]
        [HttpPost]
		public async Task<IAppResponseDto> UploadImages([FromForm] IFormCollection form,CancellationToken cancellationToken)
		{
			var containerName = form.ReadString("containerName");
			if (containerName == null ) throw new AppException("A container name is required!", HttpStatusCode.BadRequest);

			if(form.Files == null || form.Files.Count == 0)
                throw new AppException("A file is required!", HttpStatusCode.BadRequest);
            
			return await _blobService.UploadImagesAsync(form.Files, containerName, cancellationToken);
		}

        [Authorize(Roles = "admin")]
        [HttpDelete("{containerName}/{blobName}")]
		public IAppResponseDto DeleteImage(string containerName,string blobName)
		{
			return _blobService.Delete(containerName, blobName);
		}

	}
}
