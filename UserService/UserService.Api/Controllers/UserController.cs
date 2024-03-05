using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using UserService.Api.Filters;
using UserService.Application.Dtos;

namespace UserService.Api.Controllers
{
    [ServiceFilter(typeof(UserNotFoundFilter))]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IAppResponseDto> Follow(FollowDto request,CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpPost]
        public async Task<IAppResponseDto> Unfollow(UnfollowDto request, CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetFollowersAndFollowings(CancellationToken cancellationToken)
        {

            return await _sender.Send(new GetFollowersOrFollowingsDto(HttpContext.Request.Query),cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetFollowers(GetFollowersDto request, CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetFollowings(GetFollowingsDto request, CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

        [Authorize(Roles = "user")]
        [HttpGet]
        public async Task<IAppResponseDto> GetUsersByIds(CancellationToken cancellationToken)
        {
            return await _sender.Send(new GetUsersByIdsDto(Request.Query), cancellationToken);
        }
    }
}
