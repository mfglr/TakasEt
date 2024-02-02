using Common.Extentions;
using Microsoft.AspNetCore.Mvc;
using PhotoStockMicroservice.Services.Abstracts;

namespace PhotoStockMicroservice.Controllers
{
	[Route("api")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		private readonly IBlobService _blobService;

		public ImageController(IBlobService blobService)
		{
			_blobService = blobService;
		}

		[HttpGet("{containerName}/{blobName}")]
		public async Task GetImage(string containerName, string blobName,CancellationToken cancellationToken)
		{
			var bytes = await _blobService.DownloadAsync(containerName, blobName, cancellationToken);
			await Response.Body.WriteAsync(bytes,cancellationToken);
		}

		[HttpPost("upload-image")]
		public async Task UploadImage([FromForm] IFormCollection form,CancellationToken cancellationToken)
		{
			var containerName = form.ReadString("containerName");
			if (containerName == null) throw new Exception("error");

			var blobName = form.ReadString("blobName");
			if (blobName == null) throw new Exception("error");

			var file = form.Files.FirstOrDefault();
			if (file == null) throw new Exception("error");

			await _blobService.UploadAsync(file.OpenReadStream(), containerName, blobName, cancellationToken);
		}
		
		[HttpPost("upload-images")]
		public async Task UploadImages([FromForm]IFormCollection form,CancellationToken cancellationToken)
		{
			
			var containerNames = form.ReadStringList("containerNames");
			if (containerNames == null || containerNames.Count < 1) throw new Exception("error");
			
			var blobNames = form.ReadStringList("blobNames");
			if (blobNames == null) throw new Exception("error");
			if (containerNames.Count != blobNames.Count) throw new Exception("error");
			
			var streams = form.ReadStreams();
			if (blobNames.Count != streams.Count) throw new Exception("error");

			int i = 0;
			try
			{
				for(; i < streams.Count;i++)
					await _blobService.UploadAsync(
						streams[i],
						containerNames[i],
						blobNames[i],
						cancellationToken
					);
			}
			catch (Exception e)
			{
				//if there is an error when uploading files, delete the uploaded files. All or none!
				for (int j = 0; j < i; j++)
					_blobService.Delete(containerNames[j], blobNames[j]);
				throw;
			}
		}

		[HttpDelete("{containerName}/{blobName}")]
		public void DeleteImage(string containerName,string blobName)
		{
			_blobService.Delete(containerName, blobName);
		}

	}
}
