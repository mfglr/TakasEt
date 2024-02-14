using AuthService.Api.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace AuthService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignUpController : ControllerBase
    {
        private readonly ISender _sender;

        public SignUpController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<AppResponseDto> SingUpByEmail(SignUpByEmailDto request,CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }


    }
}
