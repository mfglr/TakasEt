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
		public async Task<AppResponseDto> AddProfileImageByUserId([FromForm] IFormCollection form)
		{
			return await _sender.Send(new AddProfileImageRequestDto(form));
		}

		[Authorize(Roles = "user")]
		[HttpGet("profile-image/get-active-profile-image-by-user-id/{userId}")]
		public async Task GetActiveProfileImageByUserId(Guid userId)
		{
			var bytes = await _sender.Send(new GetActiveProfileImageByIdRequestDto(userId));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}
	}
}
