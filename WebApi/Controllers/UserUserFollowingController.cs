using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
	[ApiController]
	public class UserUserFollowingController : ControllerBase
	{
		private readonly ISender _sender;

		public UserUserFollowingController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("following/follow-user")]
		public async Task<AppResponseDto> FollowUser(FollowUser request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("following/unfollow-user/{followedId}")]
		public async Task<AppResponseDto> UnfollowUser(Guid followedId)
		{
			return await _sender.Send(new UnfollowUser(followedId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("following/get-followeds/{userId}")]
		public async Task<AppResponseDto> GetFolloweds(Guid userId)
		{
			return await _sender.Send(new GetFolloweds(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("following/get-followers/{userId}")]
		public async Task<AppResponseDto> GetFollowers(Guid userId)
		{
			return await _sender.Send(new GetFollowers(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("following/is-followed/{userId}")]
		public async Task<AppResponseDto> IsFollowed(Guid userId)
		{
			return await _sender.Send(new IsFollowed(userId));
		}
	}
}
