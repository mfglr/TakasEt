using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;
using UserService.Application.Dtos;

namespace UserService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ISender _sender;

        public UserController(ISender sender)
        {
            _sender = sender;
        }


        [HttpPost]
        public async Task<IAppResponseDto> Follow(FollowDto request,CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

    }
}
