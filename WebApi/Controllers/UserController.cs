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
		public async Task<AppResponseDto> Login(LoginRequestDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPost("sing-up")]
		public async Task<AppResponseDto> SingUp(SignUpRequestDto request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/get-user-by-username/{username}")]
		public async Task<AppResponseDto> GetUserByUserName(string username)
		{
			return await _sender.Send(new GetUserByUserNameRequestDto(username));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user/remove-user/{id}")]
		public async Task<AppResponseDto> RemoveUser(Guid id)
		{
			return await _sender.Send(new RemoveUserRequestDto(id));
		}

	}
}
