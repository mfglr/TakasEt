using AuthService.Core.Entities;

namespace AuthService.Core.Abstracts
{
    public interface ITokenService
    {
        Task<string> CreateRefreshTokenAsync(UserAccount user);
        Task<bool> VerifyRefreshTokenAsync(UserAccount user, string token);
        string CreateAccessToken(UserAccount user);
    }
}
