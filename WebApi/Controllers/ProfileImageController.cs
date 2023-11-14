using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class ProfileImageController : ControllerBase
	{
		private readonly ISender _sender;

		public ProfileImageController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("profile-image/add-profile-image")]
		public async Task<AppResponseDto> AddProfileImage([FromForm] IFormCollection form)
		{
			return await _sender.Send(new AddProfileImage(form));
		}

		[Authorize(Roles = "user")]
		[HttpGet("profile-image/get-active-profile-image/{userId}")]
		public async Task GetActiveProfileImage(int userId)
		{
			var bytes = await _sender.Send(new GetActiveProfileImage(userId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}

		[Authorize(Roles = "user")]
		[HttpGet("profile-image/get-active-profile-image-by-user-name/{userName}")]
		public async Task GetActiveProfileImageByUserName(string userName)
		{
			var bytes = await _sender.Send(new GetActiveProfileImageByUserName(userName));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}
	}
}
