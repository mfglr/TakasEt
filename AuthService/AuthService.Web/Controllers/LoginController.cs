using AuthService.Web.Dtos;
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
        public async Task<AppResponseDto> LoginByEmail(LoginByEmailDto request,CancellationToken cancellation)
        {
            return await _sender.Send(request,cancellation);
        }

        [HttpPost]
        public async Task<AppResponseDto> LoginByRefreshToken(LoginByRefreshTokenDto request,CancellationToken cancellation)
        {
            return await _sender.Send(request,cancellation);
        }

    }
}
