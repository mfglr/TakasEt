using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class LoginCommandHandler : IRequestHandler<Login, AppResponseDto>
    {
        private readonly UserManager<User> _users;
		private readonly ITokenService _tokenService;
		private readonly IRepository<UserRefreshToken> _userRefreshTokens;

		public LoginCommandHandler(UserManager<User> users, ITokenService tokenService, IRepository<UserRefreshToken> userRefreshTokens)
		{
			_users = users;
			_tokenService = tokenService;
			_userRefreshTokens = userRefreshTokens;
		}

		public async Task<AppResponseDto> Handle(Login request, CancellationToken cancellationToken)
        {
			var user = await _users
				.Users
				.Include(x => x.Roles)
				.ThenInclude(x => x.Role)
				.Include(x => x.UserRefreshToken)
				.SingleOrDefaultAsync(x => x.Email == request.Email, cancellationToken);

			if (user == null) throw new UserNotFoundException();
			var result = await _users.CheckPasswordAsync(user, request.Password);
			if (!result) throw new FailedLoginException();
			var refreshToken = _tokenService.CreateRefreshToken();
			var accessToken = _tokenService.CreateAccessTokenByUser(user);
			if (user.UserRefreshToken == null)
				await _userRefreshTokens.DbSet.AddAsync(
					new UserRefreshToken(user.Id, refreshToken),
					cancellationToken
				);
			else user.UserRefreshToken.UpdateToken(refreshToken);
			var loginResponse = new LoginResponseDto(
				accessToken.Value,
				accessToken.ExpirationDate,
				refreshToken.Value,
				refreshToken.ExpirationDate,
				user.Id,
				user.UserName,
				user.Email
			);
			return AppResponseDto.Success(loginResponse);
        }
    }
}
