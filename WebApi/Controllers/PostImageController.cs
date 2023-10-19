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
		public async Task GetPostImages(Guid postId)
		{
			var bytes = await _sender.Send(new GetPostImages(postId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-first-images-of-posts-by-user-id/{userId}")]
		public async Task GetFirstImageOfPostsByUserId(Guid userId)
		{
			var bytes = await _sender.Send(new GetFirstImagesOfPostsByUserId(userId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-first-images-of-posts")]
		public async Task GetFirstImageOfPosts()
		{
			var bytes = await _sender.Send(new GetFirstImagesOfPosts(Request.Query));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-first-images-of-posts-by-user-name/{userName}")]
		public async Task GetFirstImageOfPostsByUserName(string userName)
		{
			var bytes = await _sender.Send(new GetFirstImagesOfPostsByUserName(userName));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post-image/get-first-images-of-posts-except-reuqesters/{postId}")]
		public async Task GetFirstImageOfPostsExceptReuqesters(Guid postId)
		{
			var bytes = await _sender.Send(new GetFirstImagesOfPostsExceptRequesters(postId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}
	}
}
