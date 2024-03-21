using AuthService.Application.Dtos;
using AuthService.Core.Entities;
using AuthService.Infrastructure.Extentions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Dtos;
using SharedLibrary.Exceptions;
using System.Net;
using System.Security.Claims;

namespace AuthService.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ISender _sender;
        private readonly SignInManager<UserAccount> _signInManager;
        private readonly UserManager<UserAccount> _userManager;

        public LoginController(ISender sender, SignInManager<UserAccount> signInManager, UserManager<UserAccount> userManager)
        {
            _sender = sender;
            _signInManager = signInManager;
            _userManager = userManager;
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

        [HttpGet]
        public IActionResult LoginByFacebook()
        {
            var redirectUrl = Url.Action("Response", "login");
            var properties = _signInManager.ConfigureExternalAuthenticationProperties("Facebook", redirectUrl);
            return new ChallengeResult("Facebook", properties);
        }

        public async Task<IActionResult> Response()
        {
            var info = await _signInManager.GetExternalLoginInfoAsync();

            if (info == null)
                throw new AppException("Third party authentication failed!", HttpStatusCode.InternalServerError);

            var email = info.Principal.FindFirst(ClaimTypes.Email)!.Value;

            if(!await _userManager.Users.AnyAsync(x => x.Email == email))
            {
                var user = new UserAccount(email);
                
                var result = await _userManager.CreateAsync(user);
                if(!result.Succeeded)
                    throw new AppException(result.GetErrors(), HttpStatusCode.InternalServerError);

                result = await _userManager.AddLoginAsync(user, info);
                if (!result.Succeeded)
                    throw new AppException(result.GetErrors(), HttpStatusCode.InternalServerError);
            }

            return Ok();

        }

    }
}
