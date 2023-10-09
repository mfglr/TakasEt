using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api")]
	[ApiController]
	public class UserPostViewingController : ControllerBase
	{
		private readonly ISender _sender;

		public UserPostViewingController(ISender sender)
		{
			_sender = sender;
		}
		
		[Authorize(Roles = "user")]
		[HttpPost("user-user-viewing/view-post")]
		public async Task<AppResponseDto> ViewPost(ViewPostRequestDto request)
		{
			return await _sender.Send(request);
		}
	}
}
