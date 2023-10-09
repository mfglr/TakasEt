using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
	[ApiController]
	public class UserPostLikingController : ControllerBase
	{
		private readonly ISender _sender;

		public UserPostLikingController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("user-post-like/like-post")]
		public async Task<AppResponseDto> LikePost(LikePostRequestDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("user-post-like/unlike-post/{postId}")]
		public async Task<AppResponseDto> UnlikePost(Guid postId)
		{
			return await _sender.Send(new UnlikePostRequestDto(postId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user-post-like/is-liked-logged-in-user/{postId}")]
		public async Task<AppResponseDto> IsLikedLoggedInUser(Guid postId)
		{
			return await _sender.Send(new IsLikedLoggedInUserPostRequestDto(postId));
		}
	}
}
