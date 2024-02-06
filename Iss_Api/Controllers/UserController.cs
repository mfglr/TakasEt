using Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly ISender _sender;

		public UserController(ISender sender)
		{
			_sender = sender;
		}

		[HttpPost("user/add-user-image")]
		public async Task<AppResponseDto> AddUserImage([FromForm] IFormCollection form)
		{
			return await _sender.Send(new AddUserImageDto(form));
		}

		[HttpGet("user/get-user/{userId}")]
		public async Task<AppResponseDto> GetUser(int userId)
		{
			return await _sender.Send(new GetUserDto(userId));
		}

		[HttpGet("user/get-users-who-liked-post/{postId}")]
		public async Task<AppResponseDto> GetUsersWhoLikedPost(int postId)
		{
			return await _sender.Send(new GetUsersWhoLikedPostDto(Request.Query));
		}

		[HttpGet("user/get-followeds/{userId}")]
		public async Task<AppResponseDto> GetFolloweds(int userId)
		{
			return await _sender.Send(new GetFollowedsDto(Request.Query));
		}

		[HttpGet("user/get-followers")]
		public async Task<AppResponseDto> GetFollowers()
		{
			return await _sender.Send(new GetFollowersDto(Request.Query));
		}

		[HttpGet("user/get-search-page-users")]
		public async Task<AppResponseDto> GetSearchPageUsers()
		{
			return await _sender.Send(new GetSearchPageUsersDto(Request.Query));
		}

		[HttpPut("user/follow-user")]
		public async Task<AppResponseDto> FollowUser(FollowUserDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPut("user/unfollow-user")]
		public async Task<AppResponseDto> UnfollowUser(UnfollowUserDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPut("user/remove-follower")]
		public async Task<AppResponseDto> RemoveFollower(DeleteFollowerDto request)
		{
			return await _sender.Send(request);
		}
	}
}
