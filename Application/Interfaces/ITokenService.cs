using Application.Configuration;
using Application.Entities;
using Application.ValueObjects;

namespace Application.Interfaces
{
	public interface ITokenService
	{
		Token CreateRefreshToken();
		Token CreateAccessTokenByUser(User user);
		Token CreateAccessTokenByClient(Client client);
	}
}
