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

		[Authorize(Roles = "user")]
		[HttpPost("user/add-user-image")]
		public async Task<AppResponseDto> AddUserImage([FromForm] IFormCollection form)
		{
			return await _sender.Send(new AddUserImageDto(form));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-user/{userId}")]
		public async Task<AppResponseDto> GetUser(int userId)
		{
			return await _sender.Send(new GetUserDto(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-users-who-liked-post/{postId}")]
		public async Task<AppResponseDto> GetUsersWhoLikedPost(int postId)
		{
			return await _sender.Send(new GetUsersWhoLikedPostDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-followeds/{userId}")]
		public async Task<AppResponseDto> GetFolloweds(int userId)
		{
			return await _sender.Send(new GetFollowedsDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-followers")]
		public async Task<AppResponseDto> GetFollowers()
		{
			return await _sender.Send(new GetFollowersDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-search-page-users")]
		public async Task<AppResponseDto> GetSearchPageUsers()
		{
			return await _sender.Send(new GetSearchPageUsersDto(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-user-image/{id}")]
		public async Task GetUserImage(int id)
		{
			await Response.Body.WriteAsync(await _sender.Send(new GetUserImage(id)));
		}

		[Authorize(Roles = "user")]
		[HttpPut("user/follow-user")]
		public async Task<AppResponseDto> FollowUser(FollowUserDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpPut("user/unfollow-user")]
		public async Task<AppResponseDto> UnfollowUser(UnfollowUserDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpPut("user/remove-follower")]
		public async Task<AppResponseDto> RemoveFollower(DeleteFollowerDto request)
		{
			return await _sender.Send(request);
		}
	}
}
