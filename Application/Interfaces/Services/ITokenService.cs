using Models.Configurations;
using Models.Entities;
using Models.ValueObjects;

namespace Application.Interfaces.Services
{
    public interface ITokenService
    {
        Token CreateRefreshToken();
        Token CreateAccessTokenByUser(User user);
		Token CreateAccessTokenByClient(Client client);
    }
}
