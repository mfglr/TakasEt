using AuthService.Application.Dtos;
using AuthService.Web.Filters;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace AuthService.Web.Controllers
{
    [ServiceFilter(typeof(AccountNotFoundFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize(Roles = "user")]
        [HttpPut]
        public async Task<IAppResponseDto> BlockUser(BlockUserDto request)
        {
            return await _mediator.Send(request);
        }

        [Authorize(Roles = "user")]
        [HttpPut]
        public async Task<IAppResponseDto> RemoveBlock(RemoveBlockDto request)
        {
            return await _mediator.Send(request);
        }

        [Authorize(Roles = "user")]
        [HttpGet("{userId}")]
        public async Task<IAppResponseDto> IsBlocker(string userId)
        {
            return await _mediator.Send(new IsBlockerDto() { UserId = userId });
        }

        [Authorize(Roles = "user")]
        [HttpGet("{userId}")]
        public async Task<IAppResponseDto> IsBlocked(string userId)
        {
            return await _mediator.Send(new IsBlockedDto() { UserId = userId });
        }

        [Authorize(Roles = "user")]
        [HttpGet("{userId}")]
        public async Task<IAppResponseDto> IsBlockerOrBlocked(string userId)
        {
            return await _mediator.Send(new IsBlockerOrBlockedDto() { UserId = userId });
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetBlockers(string userId)
        {
            return await _mediator.Send(new IsBlockerOrBlockedDto() { UserId = userId });
        }


    }
}
