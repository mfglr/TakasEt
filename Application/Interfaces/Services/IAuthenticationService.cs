using Application.Dtos;

namespace Application.Interfaces.Services
{
	public interface IAuthenticationService
	{
		Task<TokenDto> CreateAccessTokenAsync(LoginDto login);
		ClientTokenDto CreateAccessTokenByClient(ClientLoginDto client);
		Task<TokenDto> CreateAccessTokenByRefreshToken(string refreshTokenString);
		Task RevokeRefreshToken(string refreshToken);
	}
}
