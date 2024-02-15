using AuthService.Web.Dtos;

namespace AuthService.Web.Services
{
    internal interface IAuthenticationService
    {
        Task<LoginResponseDto> LoginByEmailAsync(string email, string password);
        Task<LoginResponseDto> LoginByRefreshTokenAsync(string refreshToken, string userId);
    }
}
