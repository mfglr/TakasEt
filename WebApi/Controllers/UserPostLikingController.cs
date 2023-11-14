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
		[HttpPost("user-post-liking/like-post")]
		public async Task<AppResponseDto> LikePost(LikePost request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("user-post-liking/unlike-post/{postId}")]
		public async Task<AppResponseDto> UnlikePost(int postId)
		{
			return await _sender.Send(new UnLikePost(postId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user-post-liking/is-liked/{postId}")]
		public async Task<AppResponseDto> IsLiked(int postId)
		{
			return await _sender.Send(new IsPostLiked(postId));
		}
	}
}
