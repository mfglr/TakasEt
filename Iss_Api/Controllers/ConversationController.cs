using Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Iss_Api.Controllers
{
	[Route("api")]
	[ApiController]
	public class ConversationController : ControllerBase
	{

		private readonly ISender _sender;

		public ConversationController(ISender sender)
		{
			_sender = sender;
		}

		[Authorize(Roles = "User")]
		[HttpPost("conversation/add-conversation-image")]
		public async Task<AppResponseDto> AddConversationImage([FromForm] IFormCollection form)
		{
			return await _sender.Send(new AddConversationImageDto(form));
		}
	}
}
