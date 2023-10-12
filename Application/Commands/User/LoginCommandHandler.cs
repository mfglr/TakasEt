using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
    public class LoginCommandHandler : IRequestHandler<Login, AppResponseDto>
	{
		private readonly UserManager<User> _userManger;
		private readonly IAuthenticationService _authenticationService;

		public LoginCommandHandler(UserManager<User> userManger, IAuthenticationService authenticationService)
		{
			_userManger = userManger;
			_authenticationService = authenticationService;
		}

		public async Task<AppResponseDto> Handle(Login request, CancellationToken cancellationToken)
		{
			var user = await _userManger
				.Users
				.Include(x => x.Roles)
				.ThenInclude(x => x.Role)
				.Include(x => x.UserRefreshToken)
				.SingleOrDefaultAsync(x => x.Email == request.Email,cancellationToken);
			if (user == null) throw new UserNotFoundException();
			var result = await _userManger.CheckPasswordAsync(user, request.Password);
			if (!result) throw new FailedLoginException();
			var token = await _authenticationService.CreateTokenByUserAsync(user, cancellationToken);
			var loginResponse = new LoginResponseDto(
				token.AccessToken,
				token.RefreshToken,
				user.Id,
				user.UserName!,
				user.Email!
			);
			return AppResponseDto.Success( loginResponse );
		}
	}
}
