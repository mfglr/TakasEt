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
		[HttpGet("post/get-home-posts")]
		public async Task<AppResponseDto> GetHomePosts()
		{
			return await _sender.Send(new GetHomePagePosts(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-explore-page-posts")]
		public async Task<AppResponseDto> GetExplorePagePosts()
		{
			return await _sender.Send(new GetExplorePagePosts(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetPostsByUserId(int userId)
		{
			return await _sender.Send(new GetPostsByUserId(userId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-except-requesters/{postId}")]
		public async Task<AppResponseDto> GetPostsExceptRequesters(int postId)
		{
			return await _sender.Send(new GetPostsExceptRequesters(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-swapped-posts/{userId}")]
		public async Task<AppResponseDto> GetSwappedPosts(int userId)
		{
			return await _sender.Send(new GetSwappedPosts(Request.Query) { UserId = userId});
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-not-swapped-posts/{userId}")]
		public async Task<AppResponseDto> GetNotSwappedPosts(int userId)
		{
			return await _sender.Send(new GetNotSwappedPosts(Request.Query) { UserId = userId });
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-category-id/{categoryId}")]
		public async Task<AppResponseDto> GetPostsByCategoryId(int categoryId)
		{
			return await _sender.Send(new GetPostsByCategoryId(Request.Query) { CategoryId = categoryId });
		}

	}
}
