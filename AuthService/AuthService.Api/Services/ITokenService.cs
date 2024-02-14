using SharedLibrary.ValueObjects;

namespace AuthService.Api.Services
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Token CreateAccessToken(string userId, string userName);
    }
}
