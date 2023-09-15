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
	public class LoginCommandHandler : IRequestHandler<LoginDto, AppResponseDto<TokenDto>>
	{
		private readonly SignInManager<User> _signInManager;
		private readonly IRepository<User> _users;
		private readonly IAuthenticationService _authenticationService;

		public LoginCommandHandler(SignInManager<User> signInManager, IRepository<User> users)
		{
			_signInManager = signInManager;
			_users = users;
		}

		public async Task<AppResponseDto<TokenDto>> Handle(LoginDto request, CancellationToken cancellationToken)
		{
			var user = await _users
				.DbSet
				.Include(x => x.Roles)
				.Include(x => x.UserRefreshToken)
				.SingleOrDefaultAsync(x => x.Email == request.Email);
			if (user == null) throw new UserNotFoundException();
			var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
			if (!result.Succeeded) throw new FailedLoginException();
			return AppResponseDto<TokenDto>.Success(
				await _authenticationService.CreateTokenByUserAsync(user)
				);
		}
	}
}
