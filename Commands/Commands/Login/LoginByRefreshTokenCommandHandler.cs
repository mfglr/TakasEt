using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.ValueObjects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Handler.Commands
{
	public class LoginByRefreshTokenCommandHandler : IRequestHandler<LoginByRefreshToken, AppResponseDto>
	{
		private readonly IRepository<User> _users;
		private readonly ITokenService _tokenService;

		public LoginByRefreshTokenCommandHandler(IRepository<User> users, ITokenService tokenService)
		{
			_users = users;
			_tokenService = tokenService;
		}

		public async Task<AppResponseDto> Handle(LoginByRefreshToken request, CancellationToken cancellationToken)
		{
			var user = await _users
				.DbSet
				.Include(x => x.Roles)
				.ThenInclude(x => x.Role)
				.Include(x => x.UserRefreshToken)
				.SingleOrDefaultAsync(
					x => x.UserRefreshToken.Token == request.RefreshToken,
					cancellationToken
				);

			if (user == null) throw new InValidRefreshTokenException();
			Token accessToken = _tokenService.CreateAccessTokenByUser(user);
			Token refreshToken = _tokenService.CreateRefreshToken();
			var loginResponse = new LoginResponseDto() {
				UserId = user.Id,
				AccessToken = accessToken.Value,
				ExpirationDateOfAccessToken = accessToken.ExpirationDate,
				RefreshToken = refreshToken.Value,
				ExpirationDateOfRefreshToken = refreshToken.ExpirationDate,
			};
			return AppResponseDto.Success(loginResponse);
		}
	}
}
