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

	}
}
