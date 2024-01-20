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
			return await _sender.Send(new AddPostDto(form));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-home-page-posts")]
		public async Task<AppResponseDto> GetHomePosts()
		{
			return await _sender.Send(new GetHomePagePostsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-search-page-posts")]
		public async Task<AppResponseDto> GetSearchPagePosts(int categoryId)
		{
			return await _sender.Send(new GetSearchPagePostsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-search-post-list-page-posts/{postId}")]
		public async Task<AppResponseDto> GetSearchPostListPagePosts(int postId)
		{
			return await _sender.Send(new GetSearchPostListPagePostsDto(Request.Query));
		}


		[Authorize(Roles = "user")]
		[HttpGet("post/get-user-posts/{userId}")]
		public async Task<AppResponseDto> GetUserPosts(int userId)
		{
			return await _sender.Send(new GetUserPostsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-except-requesters/{postId}")]
		public async Task<AppResponseDto> GetPostsExceptRequesters(int postId)
		{
			return await _sender.Send(new GetPostsExceptRequestersDto(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-swapped-posts")]
		public async Task<AppResponseDto> GetSwappedPosts()
		{
			return await _sender.Send(new GetSwappedPostsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-not-swapped-posts")]
		public async Task<AppResponseDto> GetNotSwappedPosts()
		{
			return await _sender.Send(new GetNotSwappedPostsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-category-id/{categoryId}")]
		public async Task<AppResponseDto> GetPostsByCategoryId(int categoryId)
		{
			return await _sender.Send(new GetPostsByCategoryIdDto(Request.Query) { CategoryId = categoryId });
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-key/{key}")]
		public async Task<AppResponseDto> GetPostsByKey(string key)
		{
			return await _sender.Send(new GetPostsByKeyDto(Request.Query) { Key = key });
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-filter-page-posts")]
		public async Task<AppResponseDto> GetFilterPagePosts()
		{
			return await _sender.Send(new GetFilterPagePostsDto(Request.Query));
		}

	}
}
