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
		public async Task<AppResponseDto> LikePost(LikePostDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("user-post-liking/Dislike-post/{postId}")]
		public async Task<AppResponseDto> DislikePost(DislikePostDto request)
		{
			return await _sender.Send(request);
		}
	}
}
