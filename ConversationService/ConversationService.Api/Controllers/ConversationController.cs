using ConversationService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace ConversationService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ConversationController : ControllerBase
    {
        private readonly ISender _sender;
        public ConversationController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetConversations(CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetConversationsDto(HttpContext.Request.Query), cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpGet("{userId}")]
        public async Task<IAppResponseDto> GetMessages(Guid userId,CancellationToken cancellationToken)
        {
            return await _sender.Send(
                new GetMessagesDto(HttpContext.Request.Query){ UserId = userId},
                cancellationToken
            );
        }

    }
}
