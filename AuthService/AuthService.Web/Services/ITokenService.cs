using SharedLibrary.ValueObjects;

namespace AuthService.Web.Services
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Token CreateAccessToken(string userId, string userName);
    }
}
