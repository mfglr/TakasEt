using Application.Dtos;
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
		[HttpGet("user/get-user-by-username/{username}")]
		public async Task<AppResponseDto> GetUserByUserName(string username)
		{
			return await _sender.Send(new GetUserByUserName(username));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-user/{userId}")]
		public async Task<AppResponseDto> GetUser(int userId)
		{
			return await _sender.Send(new GetUser(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-users-who-liked-post/{postId}")]
		public async Task<AppResponseDto> GetUsersWhoLikedPost(int postId)
		{
			return await _sender.Send(new GetUsersWhoLikedPost(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-users-by-filter")]
		public async Task<AppResponseDto> GetUsersThatByFilter()
		{
			return await _sender.Send(new GetUsersByFilter(Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-followeds/{userId}")]
		public async Task<AppResponseDto> GetFolloweds(int userId)
		{
			return await _sender.Send(new GetFolloweds(Request.Query) { UserId = userId});
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-followers/{userId}")]
		public async Task<AppResponseDto> GetFollowers(int userId)
		{
			return await _sender.Send(new GetFollowers(Request.Query) { UserId = userId});
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-search-page-users")]
		public async Task<AppResponseDto> GetSearchPageUsers(string key)
		{
			return await _sender.Send(new GetSearchPageUsers(Request.Query) { Key = key });
		}


	}
}
