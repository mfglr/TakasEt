using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class PostPostRequestingController : ControllerBase
	{
		private readonly ISender _sender;

		public PostPostRequestingController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "user")]
		[HttpPost("requesting/add-requestings")]
		public async Task<AppResponseDto> AddRequestings(AddRequestings request)
		{
			return await _sender.Send(request);
		}

		[Authorize(Roles = "user")]
		[HttpGet("requesting/get-requesters/{postId}")]
		public async Task<AppResponseDto> GetRequesters(int postId)
		{
			return await _sender.Send(new GetRequesters(postId));
		}
	}
}
