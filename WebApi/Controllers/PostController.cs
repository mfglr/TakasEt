using Application.Dtos;
using Application.Dtos.Post;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class PostController : ControllerBase
	{
		private readonly ISender _sender;

		public PostController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("post/add-post")]
		public async Task<AppResponseDto> AddPost([FromForm]IFormCollection form)
		{
			return await _sender.Send(new AddPost(form));
		}

		[Authorize(Roles = "user")]
		[HttpDelete("post/remove-post")]
		public async Task<AppResponseDto> RemovePost(RemovePost request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-post/{id}")]
		public async Task<AppResponseDto> GetPost(Guid id)
		{
			return await _sender.Send(new GetPost(id));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts")]
		public async Task<AppResponseDto> GetPosts()
		{
			return await _sender.Send(new GetPosts());
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetPostsByUserId(Guid userId)
		{
			return await _sender.Send(new GetPostsByUserId(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-user-name/{userName}")]
		public async Task<AppResponseDto> GetPostsByUserName(string userName)
		{
			return await _sender.Send(new GetPostsByUserName(userName));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-except-requesters/{postId}")]
		public async Task<AppResponseDto> GetPostsExceptRequesters(Guid postId)
		{
			return await _sender.Send(new GetPostsExceptRequesters(postId));
		}



	}
}
