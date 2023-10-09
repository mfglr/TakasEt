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
		[HttpGet("post-image/get-post-images-by-post-id/{postId}")]
		public async Task GetPostImagesByPostId(Guid postId)
		{
			var bytes = await _sender.Send(new GetPostImagesByPostIdRequestDto(postId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-first-image-of-posts-by-user-id/{userId}")]
		public async Task GetFirstImageOfPostsByUserId(Guid userId)
		{
			var bytes = await _sender.Send(new GetFirstImageOfPostsByUserIdRequestDto(userId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}
	}
}
