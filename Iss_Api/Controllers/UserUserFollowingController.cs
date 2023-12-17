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
		[HttpDelete("following/unfollow-user/{userId}")]
		public async Task<AppResponseDto> UnfollowUser(int userId)
		{
			return await _sender.Send(new UnfollowUser(userId));
		}

		[Authorize(Roles = "user")]
		[HttpDelete("following/remove-follower/{userId}")]
		public async Task<AppResponseDto> RemoveFollower(int userId)
		{
			return await _sender.Send(new RemoveFollower() { FollowerId = userId });
		}
	}
}
