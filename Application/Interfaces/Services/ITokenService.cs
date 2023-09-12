using Application.Configurations;
using Application.Entities;
using Application.ValueObjects;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Task<Token> CreateAccessTokenByUserAsync(User user);
		Token CreateAccessTokenByClient(Client client);
    }
}
