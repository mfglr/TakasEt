using AuthService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace AuthService.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISender _sender;

        public LoginController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IAppResponseDto> LoginByEmail(LoginByEmailDto request,CancellationToken cancellation)
        {
            return await _sender.Send(request,cancellation);
        }

        [HttpPost]
        public async Task<IAppResponseDto> LoginByRefreshToken(LoginByRefreshTokenDto request,CancellationToken cancellation)
        {
            return await _sender.Send(request,cancellation);
        }

    }
}
