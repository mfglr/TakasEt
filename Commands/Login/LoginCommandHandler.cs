using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Models.Dtos;
using Models.Entities;
using Models.Exceptions;

namespace Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginDto, AppResponseDto>
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

        public async Task<AppResponseDto> Handle(LoginDto request, CancellationToken cancellationToken)
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
                    new UserRefreshToken(user.Id, refreshToken.Value, refreshToken.ExpirationDate),
                    cancellationToken
                );
            else user.UserRefreshToken.UpdateToken(refreshToken.Value, refreshToken.ExpirationDate);

            var loginResponse = new LoginResponseDto()
            {
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
