using AuthService.Core.Entities;

namespace AuthService.Core.Abstracts
{
    public interface ITokenService
    {
        Task<string> CreateRefreshTokenAsync(string userId);
        Task<bool> VerifyRefreshTokenAsync(UserAccount user, string token);
        Task<string> CreateAccessTokenAsync(string userId);
    }
}
