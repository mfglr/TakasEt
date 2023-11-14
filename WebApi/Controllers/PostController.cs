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
		[HttpGet("post/get-post/{id}")]
		public async Task<AppResponseDto> GetPost(int id)
		{
			return await _sender.Send(new GetPost(id));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts")]
		public async Task<AppResponseDto> GetPosts()
		{
			return await _sender.Send(new GetPosts(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetPostsByUserId(int userId)
		{
			return await _sender.Send(new GetPostsByUserId(userId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-user-name/{userName}")]
		public async Task<AppResponseDto> GetPostsByUserName(string userName)
		{
			return await _sender.Send(new GetPostsByUserName(userName,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-except-requesters/{postId}")]
		public async Task<AppResponseDto> GetPostsExceptRequesters(int postId)
		{
			return await _sender.Send(new GetPostsExceptRequesters(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-filter/")]
		public async Task<AppResponseDto> GetPostsByFilter()
		{
			return await _sender.Send(new GetPostsByFilter(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-followed-users")]
		public async Task<AppResponseDto> GetPostsByFollowedUsers(int userId)
		{
			return await _sender.Send(new GetPostsByFollowedUsers(Request.Query));
		}

	}
}
