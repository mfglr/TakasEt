﻿using Models.Dtos;
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

		[HttpPost("post/add-post")]
		public async Task<AppResponseDto> AddPost([FromForm]IFormCollection form)
		{
			return await _sender.Send(new AddPostDto(form));
		}

		[HttpGet("post/get-home-page-posts")]
		public async Task<AppResponseDto> GetHomePosts()
		{
			return await _sender.Send(new GetHomePagePostsDto(Request.Query));
		}

		[HttpGet("post/get-search-page-posts")]
		public async Task<AppResponseDto> GetSearchPagePosts(int categoryId)
		{
			return await _sender.Send(new GetSearchPagePostsDto(Request.Query));
		}

		[HttpGet("post/get-search-post-list-page-posts/{postId}")]
		public async Task<AppResponseDto> GetSearchPostListPagePosts(int postId)
		{
			return await _sender.Send(new GetSearchPostListPagePostsDto(Request.Query));
		}


		[HttpGet("post/get-user-posts/{userId}")]
		public async Task<AppResponseDto> GetUserPosts(int userId)
		{
			return await _sender.Send(new GetUserPostsDto(Request.Query));
		}

		[HttpGet("post/get-posts-except-requesters/{postId}")]
		public async Task<AppResponseDto> GetPostsExceptRequesters(int postId)
		{
			return await _sender.Send(new GetPostsExceptRequestersDto(postId,Request.Query));
		}

		[HttpGet("post/get-swapped-posts")]
		public async Task<AppResponseDto> GetSwappedPosts()
		{
			return await _sender.Send(new GetSwappedPostsDto(Request.Query));
		}

		[HttpGet("post/get-not-swapped-posts")]
		public async Task<AppResponseDto> GetNotSwappedPosts()
		{
			return await _sender.Send(new GetNotSwappedPostsDto(Request.Query));
		}

		[HttpGet("post/get-posts-by-category-id/{categoryId}")]
		public async Task<AppResponseDto> GetPostsByCategoryId(int categoryId)
		{
			return await _sender.Send(new GetPostsByCategoryIdDto(Request.Query) { CategoryId = categoryId });
		}

		[HttpGet("post/get-posts-by-key/{key}")]
		public async Task<AppResponseDto> GetPostsByKey(string key)
		{
			return await _sender.Send(new GetPostsByKeyDto(Request.Query) { Key = key });
		}

		[HttpGet("post/get-filter-page-posts")]
		public async Task<AppResponseDto> GetFilterPagePosts()
		{
			return await _sender.Send(new GetFilterPagePostsDto(Request.Query));
		}

		[HttpPut("post/like-post")]
		public async Task<AppResponseDto> LikePost(LikePostDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPut("post/dislike-post")]
		public async Task<AppResponseDto> DislikePost(DislikePostDto request)
		{
			return await _sender.Send(request);
		}
		
		[HttpGet("post/get-post-images")]
		public async Task<AppResponseDto> GetPostImages()
		{
			return await _sender.Send(new GetPostImagesDto(Request.Query));
		}
	}
}
