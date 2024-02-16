using AuthService.Web.Entities;
using SharedLibrary.ValueObjects;

namespace AuthService.Web.Services
{
    internal interface ITokenService
    {
        Task<string> CreateRefreshTokenAsync(UserAccount user);
        Task<bool> VerifyRefreshTokenAsync(UserAccount user, string token);
        string CreateAccessToken(UserAccount user);
    }
}
