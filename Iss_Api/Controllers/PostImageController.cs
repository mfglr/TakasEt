using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class PostImageController : ControllerBase
	{
		private readonly ISender _sender;

		public PostImageController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-post-images/{postId}")]
		public async Task<AppResponseDto> GetPostImages(int postId)
		{
			return await _sender.Send(new GetPostImages(Request.Query,postId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-post-image/{id}")]
		public async Task GetPostImage(int id)
		{
			await Response.Body.WriteAsync(
				await _sender.Send(new GetPostImage() { Id = id})
			);
		}
	}
}
