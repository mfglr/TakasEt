using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly ITokenService _tokenService;
		private readonly List<Client> _clients;
		private readonly IRepository<UserRefreshToken> _userRefreshTokenRepository;

		public AuthenticationService(ITokenService tokenService, List<Client> clients, IRepository<UserRefreshToken> userRefreshTokenRepository)
		{
			_tokenService = tokenService;
			_clients = clients;
			_userRefreshTokenRepository = userRefreshTokenRepository;
		}

		public async Task<TokenDto> CreateTokenByUserAsync(User user)
		{
			Token? newRefreshToken = user.UserRefreshToken?.Token;
			if (newRefreshToken == null)
			{
				newRefreshToken = _tokenService.CreateRefreshToken();
				await _userRefreshTokenRepository.DbSet.AddAsync(new UserRefreshToken(user.Id, newRefreshToken));
			}
			else if (!newRefreshToken.IsValid())
				user.UserRefreshToken!.UpdateToken(_tokenService.CreateRefreshToken());
			var accessToken = _tokenService.CreateAccessTokenByUser(user);
			return new TokenDto(
				accessToken.Value,
				accessToken.ExpirationDate,
				newRefreshToken!.Value,
				accessToken.ExpirationDate
			);

		}

		public ClientTokenDto CreateTokenByClient(ClientLoginDto client)
		{
			var avaibleClient = _clients.SingleOrDefault(x => x.Id == client.Id && x.Secret == client.Secret);
			if (avaibleClient == null) throw new ClientNotFoundException();
			Token accessToken = _tokenService.CreateAccessTokenByClient(avaibleClient);
			return new ClientTokenDto(accessToken.Value, accessToken.ExpirationDate);
		}

		public async Task<TokenDto> CreateAccessTokenByRefreshTokenAsync(string refreshTokenString)
		{
			var userRefreshToken = await _userRefreshTokenRepository
				.DbSet
				.Include(x => x.User)
				.SingleOrDefaultAsync( x => x.Token.Value == refreshTokenString);
			if (userRefreshToken == null || !userRefreshToken.Token.IsValid()) throw new InValidRefreshTokenException();
			Token accessToken = _tokenService.CreateAccessTokenByUser(userRefreshToken.User);
			Token refreshToken = userRefreshToken.Token;
			return new TokenDto(
				accessToken.Value,
				accessToken.ExpirationDate,
				refreshToken.Value,
				refreshToken.ExpirationDate
			);
		}

		public async Task RevokeRefreshTokenAsync(string refreshToken)
		{
			var userRefreshToken = await _userRefreshTokenRepository.DbSet.SingleOrDefaultAsync(x => x.Token.Value == refreshToken);
			if (userRefreshToken == null) throw new RefreshTokenNotFoundException();
			_userRefreshTokenRepository.DbSet.Remove(userRefreshToken);
		}
	}
}
