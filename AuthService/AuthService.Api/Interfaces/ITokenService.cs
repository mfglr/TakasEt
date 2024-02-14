using SharedLibrary.ValueObjects;

namespace AuthService.Api.Interfaces
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Token CreateAccessToken(string userId, string userName);
    }
}
