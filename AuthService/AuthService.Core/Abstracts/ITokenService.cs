using AuthService.Core.Entities;
using AuthService.Core.ValueObjects;

namespace AuthService.Core.Abstracts
{
    public interface ITokenService
    {
        Task<Token> CreateRefreshTokenAsync(string userId);
        Task<bool> VerifyRefreshTokenAsync(UserAccount user, string token);
        Task<Token> CreateAccessTokenAsync(string userId,string timeZone,int offset);
    }
}
