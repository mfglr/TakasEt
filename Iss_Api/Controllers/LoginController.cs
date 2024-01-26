using Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ISender _sender;

		public LoginController(ISender sender)
		{
			_sender = sender;
		}

		[HttpPost("login")]
		public async Task<AppResponseDto> Login(LoginDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPost("login-by-refresh-token")]
		public async Task<AppResponseDto> LoginByRefreshToken(LoginByRefreshTokenDto request)
		{
			return await _sender.Send(request);
		}

		[HttpPost("sing-up")]
		public async Task<AppResponseDto> SingUp(SignUpDto request)
		{
			return await _sender.Send(request);
		}
	}
}
