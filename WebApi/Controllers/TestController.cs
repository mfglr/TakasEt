using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class TestController : ControllerBase
	{

		private readonly ISender _sender;

		public TestController(ISender sender)
		{
			_sender = sender;
		}

		[HttpGet("test/deneme")]
		public async Task<AppResponseDto> Deneme()
		{
			return await _sender.Send(new Deneme());
		}
	}
}
