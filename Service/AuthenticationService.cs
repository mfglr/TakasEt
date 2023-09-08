using Application.Configurations;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Service
{
	public class AuthenticationService : IAuthenticationService
	{
		private readonly TokenService _tokenService;
		private readonly List<Client> _clients;
		private readonly UserManager<User> _userManager;
		private readonly IRepository<UserRefreshToken> _userRefreshTokenRepository;

		public AuthenticationService(TokenService tokenService, List<Client> clients, UserManager<User> userManager, IRepository<UserRefreshToken> userRefreshTokenRepository)
		{
			_tokenService = tokenService;
			_clients = clients;
			_userManager = userManager;
			_userRefreshTokenRepository = userRefreshTokenRepository;
		}


		public async Task<TokenDto> CreateAccessTokenAsync(LoginDto login)
		{
			var user = await _userManager.FindByEmailAsync(login.Email);
			if (user == null) throw new Exception("hata");
			if (!await _userManager.CheckPasswordAsync(user, login.Password)) throw new Exception("hata");
			
			var accessToken = _tokenService.CreateAccessTokenByUser(user);

			var userRefreshToken = await _userRefreshTokenRepository
				.DbSet
				.OrderBy(x => x.CreatedDate)
				.FirstOrDefaultAsync(x => x.Id == user.Id);
			
			Token newRefreshToken = userRefreshToken?.Token;

			if (userRefreshToken == null || !userRefreshToken.Token.IsValid() || userRefreshToken.IsDeleted)
			{
				userRefreshToken?.Delete();
				newRefreshToken = _tokenService.CreateRefreshToken();
				await _userRefreshTokenRepository
					.DbSet
					.AddAsync(new UserRefreshToken(user.Id, newRefreshToken));
			}

			return new TokenDto(
				accessToken.Value,
				accessToken.ExpirationDate, 
				newRefreshToken.Value,
				accessToken.ExpirationDate
			);

		}


		public ClientTokenDto CreateAccessTokenByClient(ClientLoginDto client)
		{
			var avaibleClient = _clients.SingleOrDefault(x => x.Id == client.Id && x.Secret == client.Secret);
			if (avaibleClient == null) throw new Exception("hata");
			Token accessToken = _tokenService.CreateAccessTokenByClient(avaibleClient);
			return new ClientTokenDto(accessToken.Value, accessToken.ExpirationDate);
		}

		public async Task<TokenDto> CreateAccessTokenByRefreshToken(string refreshTokenString)
		{
			var userRefreshToken = await _userRefreshTokenRepository
				.DbSet
				.Include(x => x.User)
				.OrderBy(x => x.CreatedDate)
				.SingleOrDefaultAsync( x => x.Token.Value == refreshTokenString);

			if (userRefreshToken == null || !userRefreshToken.Token.IsValid()) throw new Exception("hata");
			Token accessToken = _tokenService.CreateAccessTokenByUser(userRefreshToken.User);
			Token refreshToken = userRefreshToken.Token;
			return new TokenDto(
				accessToken.Value,
				accessToken.ExpirationDate,
				refreshToken.Value,
				refreshToken.ExpirationDate
			);
		}

		public async Task RevokeRefreshToken(string refreshToken)
		{
			var userRefreshToken = await _userRefreshTokenRepository.DbSet.SingleOrDefaultAsync(x => x.Token.Value == refreshToken);
			if (refreshToken == null) throw new Exception("hata");
			userRefreshToken.Delete();
		}

	}
}
