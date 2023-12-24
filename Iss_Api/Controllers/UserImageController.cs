using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class UserImageController : ControllerBase
	{
		private readonly ISender _sender;

		public UserImageController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("user-image/add-user-image")]
		public async Task<AppResponseDto> AddUserImage([FromForm] IFormCollection form)
		{
			return await _sender.Send(new AddUserImage(form));
		}

		[Authorize(Roles = "user")]
		[HttpGet("user-image/get-user-image/{id}")]
		public async Task GetUserImage(int id)
		{
			await Response.Body.WriteAsync(
				await _sender.Send(new GetUserImage() { Id = id })
			);
		}

	}
}
