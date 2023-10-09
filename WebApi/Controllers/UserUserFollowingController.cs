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
		[HttpPost("user-user-following/followed-user")]
		public async Task<AppResponseDto> AddFollowed(FollowUserRequestDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpDelete("user-user-following/unfollowed-user")]
		public async Task<AppResponseDto> RemoveFollowed(UnfollowUserRequestDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("user-user-following/get-followeds-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetFollowedsById(Guid userId)
		{
			return await _sender.Send(new GetFollowedsByUserIdRequestDto(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user-user-following/get-followers-by-user-id/{userId}")]
		public async Task<AppResponseDto> GetFollowersById(Guid userId)
		{
			return await _sender.Send(new GetFollowersByUserIdRequestDto(userId));
		}
	}
}
