using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class AppFileController : ControllerBase
	{
		private readonly ISender _sender;

		public AppFileController(ISender sender)
		{
			_sender = sender;
		}

		//[Authorize(Roles = "user")]
		[HttpGet("app-file/get-app-file/{id}")]
		public async Task<IActionResult> GetAppFile(int id)
		{
			var stream = await _sender.Send(new GetAppFile(id));
			return File(stream, "application/octet-stream");	
		}
	}
}
