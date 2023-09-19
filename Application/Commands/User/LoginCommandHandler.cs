using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class LoginCommandHandler : IRequestHandler<LoginDto, AppResponseDto>
	{
		private readonly SignInManager<User> _signInManager;
		private readonly UserManager<User> _userManger;
		private readonly IAuthenticationService _authenticationService;

		public LoginCommandHandler(SignInManager<User> signInManager, UserManager<User> userManger, IAuthenticationService authenticationService)
		{
			_signInManager = signInManager;
			_userManger = userManger;
			_authenticationService = authenticationService;
		}

		public async Task<AppResponseDto> Handle(LoginDto request, CancellationToken cancellationToken)
		{
			var user = await _userManger
				.Users
				.Include(x => x.Roles)
				.ThenInclude(x => x.Role)
				.Include(x => x.UserRefreshToken)
				.SingleOrDefaultAsync(x => x.Email == request.Email);
			if (user == null) throw new UserNotFoundException();
			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (!result.Succeeded) throw new FailedLoginException();
			return AppResponseDto.Success(
				await _authenticationService.CreateTokenByUserAsync(user)
				);
		}
	}
}
