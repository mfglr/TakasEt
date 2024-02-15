using AuthService.Web.Entities;
using SharedLibrary.ValueObjects;

namespace AuthService.Web.Services
{
    internal interface ITokenService
    {
        Task<string> CreateRefreshTokenAsync(User user);
        Task<bool> VerifyRefreshTokenAsync(User user, string token);
        string CreateAccessToken(User user);
    }
}
