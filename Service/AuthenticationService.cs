using Application.Configuration;
using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
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

		//public ClientTokenDto CreateClientTokenDto(ClientLoginDto login)
		//{
		//	var client = _clients.FirstOrDefault(x => x.Id == login.ClientId && x.Secret == login.ClientSecret);
		//	if (client == null) throw new Exception("Client id or client secret are not found");
		//	var token = _tokenService.CreateAccessTokenByClient(client);
		//	return new 
		//}

		//public async Task<AccessTokenDto> CreateTokenAsync(LoginDto login)
		//{
		//	var user = await _userManager.FindByEmailAsync(login.Email);
		//	if (user == null) throw new Exception("Email or Password is wrong");
		//	if(!(await _userManager.CheckPasswordAsync(user, login.Password)))
		//		throw new Exception("Email or Password is wrong");
			
		//	var userRefreshToken = await _userRefreshTokenRepository
		//		.Where(x => x.UserId == user.Id)
		//		.AsNoTracking()
		//		.FirstOrDefaultAsync();
			
		//	var token = _tokenService.CreateTokenByUser(user);
			
		//	if (userRefreshToken == null)
		//		await _userRefreshTokenRepository.AddAsync(new UserRefreshToken(user.Id,token.RefreshToken,token.ExpirationOfRefreshToken));
  //          else
		//		userRefreshToken.UpdateRefreshToken(token.RefreshToken,token.ExpirationOfRefreshToken);
            
		//	return token;
		//}

		//public async Task<AccessTokenDto> CreateTokensByRefreshTokenAsync(string refreshToken)
		//{
		//	var userRefreshToken = await _userRefreshTokenRepository
		//		.Where(x => x.Token == refreshToken)
		//		.AsNoTracking()
		//		.Include(x => x.User)
		//		.FirstOrDefaultAsync();
			
		//	if (userRefreshToken == null) throw new Exception("Refresh Token is not found!");
		//	if (userRefreshToken.User == null) throw new Exception("User not found when creating refresh token!");
		//	var token = _tokenService.CreateTokenByUser(userRefreshToken.User);
		//	if (!userRefreshToken.IsValid())
		//		userRefreshToken.UpdateRefreshToken(token.RefreshToken, token.ExpirationOfRefreshToken);
		//	return token;
		//}

		//public Task RevokeRefreshToken(string refreshToken)
		//{
		//	throw new NotImplementedException();
		//}
	}
}
