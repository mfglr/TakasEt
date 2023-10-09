using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class PostController : ControllerBase
	{
		// RerPs : requester posts
		// LIU : Logged in user
		private readonly ISender _sender;

		public PostController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("post/add-post")]
		public async Task<AppResponseDto> AddPost([FromForm]IFormCollection form)
		{
			return await _sender.Send(new AddPostRequestDto(form));
		}

		[Authorize(Roles = "user")]
		[HttpDelete("post/remove-post")]
		public async Task<AppResponseDto> RemovePost(RemovePostRequestDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("post/get-by-id/{id}")]
		public async Task<AppResponseDto> GetPostById(Guid id)
		{
			return await _sender.Send(new GetPostByIdRequestDto(id));
		}
		
		[Authorize(Roles = "user")]
		[HttpGet("post/get-posts-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetPostsByUserId(Guid userId)
		{
			return await _sender.Send(new GetPostsByUserIdRequestDto(userId));
		}

	}
}
