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
		public async Task<AppResponseDto> GetUser(Guid userId)
		{
			return await _sender.Send(new GetUser(userId));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-users-who-liked-post/{postId}")]
		public async Task<AppResponseDto> GetUsersWhoLikedPost(Guid postId)
		{
			return await _sender.Send(new GetUsersWhoLikedPost(postId,Request.Query));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-users-by-filter")]
		public async Task<AppResponseDto> GetUsersThatByFilter()
		{
			return await _sender.Send(new GetUsersByFilter(Request.Query));
		}




	}
}
