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

		[Authorize(Roles = "user")]
		[HttpGet("app-file/get-app-file/{containerName}/{blobName}")]
		public async Task GetAppFile(string containerName,string blobName)
		{
			var bytes = await _sender.Send(new GetAppFile(blobName, containerName));
			await Response.Body.WriteAsync(bytes, 0, bytes.Length);
		}
	}
}
