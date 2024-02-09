using Microsoft.AspNetCore.Mvc;
using PhotoStockMicroservice.Api.Services.Abstracts;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using System.Net;

namespace PhotoStockMicroservice.Api.Controllers
{
    [Route("api/[Controller]/[Action]")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		private readonly IBlobService _blobService;

		public ImageController(IBlobService blobService)
		{
			_blobService = blobService;
		}

        [HttpPost("{containerName}")]
        public void CreateContainer(string containerName)
        {
            _blobService.CreateContainer(containerName);
        }

        [HttpGet("{containerName}/{blobName}")]
		public async Task DownloadImage(string containerName, string blobName,CancellationToken cancellationToken)
		{
			var bytes = await _blobService.DownloadAsync(containerName, blobName, cancellationToken);
			await Response.Body.WriteAsync(bytes,cancellationToken);
		}

		[HttpPost]
		public async Task<AppResponseDto> UploadImage([FromForm] IFormCollection form,CancellationToken cancellationToken)
		{
			var containerName = form.ReadString("containerName");
			if (containerName == null) throw new AppException("A container name is required!",HttpStatusCode.BadRequest);

			var file = form.Files.FirstOrDefault();
			if (file == null) throw new AppException("A file is required!", HttpStatusCode.BadRequest);

			return await _blobService.UploadImageAsync(file, containerName, cancellationToken);
		}
		
		[HttpPost]
		public async Task<AppResponseDto> UploadImages([FromForm] IFormCollection form,CancellationToken cancellationToken)
		{
			var containerName = form.ReadString("containerName");
			if (containerName == null ) throw new AppException("A container name is required!", HttpStatusCode.BadRequest);
			return await _blobService.UploadImagesAsync(form.Files, containerName, cancellationToken);
		}

		[HttpDelete("{containerName}/{blobName}")]
		public AppResponseDto DeleteImage(string containerName,string blobName)
		{
			return _blobService.Delete(containerName, blobName);
		}

	}
}
