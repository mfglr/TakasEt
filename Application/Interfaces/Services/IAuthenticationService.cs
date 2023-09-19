using Application.Dtos;
using Application.Entities;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
	{
		Task<TokenDto> CreateTokenByUserAsync(User user, CancellationToken cancellationToken);
		ClientTokenDto CreateTokenByClient(ClientLoginDto client);
		Task<TokenDto> CreateAccessTokenByRefreshTokenAsync(string refreshTokenString, CancellationToken cancellationToken);
		Task RevokeRefreshTokenAsync(string refreshToken, CancellationToken cancellationToken);
	}
}
