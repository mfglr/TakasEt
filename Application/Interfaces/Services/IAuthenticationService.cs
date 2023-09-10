using Application.Dtos;

namespace Application.Interfaces.Services
{
    public interface IAuthenticationService
	{
		Task<TokenDto> CreateTokenByUserAsync(LoginDto login);
		ClientTokenDto CreateTokenByClient(ClientLoginDto client);
		Task<TokenDto> CreateAccessTokenByRefreshTokenAsync(string refreshTokenString);
		Task RevokeRefreshToken(string refreshToken);
	}
}
