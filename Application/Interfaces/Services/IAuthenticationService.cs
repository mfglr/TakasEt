using Application.Dtos;
using Application.Entities;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
	{
		Task<TokenDto> CreateTokenByUserAsync(User user);
		ClientTokenDto CreateTokenByClient(ClientLoginDto client);
		Task<TokenDto> CreateAccessTokenByRefreshTokenAsync(string refreshTokenString);
		Task RevokeRefreshTokenAsync(string refreshToken);
	}
}
