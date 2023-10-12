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

		[HttpPost("login")]
		public async Task<AppResponseDto> Login(Login request)
		{
			return await _sender.Send(request);
		}

		[HttpPost("sing-up")]
		public async Task<AppResponseDto> SingUp(SignUp request)
		{
			return await _sender.Send(request);
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
		[HttpGet("user/remove-user/{id}")]
		public async Task<AppResponseDto> RemoveUser(Guid id)
		{
			return await _sender.Send(new RemoveUserRequestDto(id));
		}

	}
}
