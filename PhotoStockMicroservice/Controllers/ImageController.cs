using MediatR;
using Microsoft.AspNetCore.Mvc;
using Models.Dtos;

namespace PhotoStockMicroservice.Controllers
{
	[Route("api")]
	[ApiController]
	public class ImageController : ControllerBase
	{
		private readonly ISender _sender;

		public ImageController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("post-image/{blobName}")]
		public async Task GetPostImage(string blobName)
		{
			await Response.Body.WriteAsync(await _sender.Send(new GetPostImageDto(blobName)));
		}

		[HttpGet("user-image/{blobName}")]
		public async Task GetUserImage(string blobName)
		{
			await Response.Body.WriteAsync(await _sender.Send(new GetUserImageDto(blobName)));
		}

		[HttpGet("group-image/{blobName}")]
		public async Task GetGroupImage(string blobName)
		{
			await Response.Body.WriteAsync(await _sender.Send(new GetGroupImageDto(blobName)));
		}

		[HttpGet("message-image/{blobName}")]
		public async Task GetMessageImage(string blobName)
		{
			await Response.Body.WriteAsync(await _sender.Send(new GetMessageImageDto(blobName)));
		}

		[HttpGet("story-image/{blobName}")]
		public async Task GetStoryImage(string blobName)
		{
			await Response.Body.WriteAsync(await _sender.Send(new GetStoryImageDto(blobName)));
		}


	}
}
