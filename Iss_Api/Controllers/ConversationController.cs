using Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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

		[HttpGet("conversation/get-conversations")]
		public async Task<AppResponseDto> GetConversations()
		{
			return await _sender.Send(new GetConversationsDto(Request.Query));
		}
		
	}
}
