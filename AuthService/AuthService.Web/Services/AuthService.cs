using AuthService.Web.Dtos;
using AuthService.Web.Entities;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Exceptions;
using System.Net;

namespace AuthService.Web.Services
{
    internal class AuthenticationService : IAuthenticationService
    {
        private readonly ITokenService _tokenService;
        private readonly UserManager<UserAccount> _userManager;

        public AuthenticationService(ITokenService tokenService, UserManager<UserAccount> userManager)
        {
            _tokenService = tokenService;
            _userManager = userManager;
        }

        public async Task<LoginResponseDto> LoginByEmailAsync(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (
                user == null ||
                !await _userManager.CheckPasswordAsync(user, password)
            )
                throw new AppException("Email or password wrong!", HttpStatusCode.BadRequest);

            return new LoginResponseDto()
            {
                UserId = user.Id,
                AccessToken = _tokenService.CreateAccessToken(user),
                RefreshToken = await _tokenService.CreateRefreshTokenAsync(user),
            };
        }

        public async Task<LoginResponseDto> LoginByRefreshTokenAsync(string refreshToken,string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (
                user == null ||
                !await _tokenService.VerifyRefreshTokenAsync(user, refreshToken)
            )
                throw new AppException("Invalid token!", HttpStatusCode.BadRequest);


            var response = new LoginResponseDto()
            {
                UserId = user.Id,
                AccessToken = _tokenService.CreateAccessToken(user),
                RefreshToken = await _tokenService.CreateRefreshTokenAsync(user),
            };

          
            return response;

        }


    }
}
