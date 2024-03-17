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
        private readonly IMediator _mediator;

        public ConversationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetConversations(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetConversationsDto(Request.Query), cancellationToken);
        }


    }
}
