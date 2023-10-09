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

		[Authorize(Roles = "admin")]
		[HttpGet("app-file/get-by-key/{containerName}/{blobName}")]
		public async Task<byte[]> GetByKey(string containerName,string blobName)
		{
			return await _sender.Send(new GetAppFileByKeyRequestDto(blobName, containerName));
		}
	}
}
