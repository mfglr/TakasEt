using SharedLibrary.ValueObjects;

namespace AuthService.Core.Interfaces
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Token CreateAccessToken(string userId, string userName);
    }
}
