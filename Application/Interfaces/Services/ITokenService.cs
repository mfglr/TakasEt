using Application.Configurations;
using Application.Entities;
using Application.ValueObjects;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Token CreateAccessTokenByUser(User user);
        Token CreateAccessTokenByClient(Client client);
    }
}
