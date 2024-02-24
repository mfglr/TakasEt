using AuthService.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using SharedLibrary.Dtos;

namespace AuthService.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SignUpController : Controller
    {
        private readonly ISender _sender;

        public SignUpController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<IAppResponseDto> SingUpByEmail(SignUpByEmailDto request,CancellationToken cancellationToken)
        {
            return await _sender.Send(request, cancellationToken);
        }

    }
}
