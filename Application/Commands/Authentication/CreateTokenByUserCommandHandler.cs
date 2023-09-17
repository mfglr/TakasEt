using Application.Dtos;
using Application.Entities;
using Application.Exceptions;
using Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Commands
{
	public class CreateTokenByUserCommandHandler : IRequestHandler<LoginDto, AppResponseDto<TokenDto>>
	{

		private readonly IAuthenticationService _authenticationService;
		private readonly UserManager<User> _userManager;

		public CreateTokenByUserCommandHandler(IAuthenticationService authenticationService, UserManager<User> userManager)
		{
			_authenticationService = authenticationService;
			_userManager = userManager;
		}

		public async Task<AppResponseDto<TokenDto>> Handle(LoginDto request, CancellationToken cancellationToken)
		{
			var user = await _userManager
				.Users
				.Include(x => x.Roles)
				.ThenInclude(x => x.Role)
				.Include(x => x.UserRefreshToken)
				.SingleOrDefaultAsync(x => x.Email == request.Email);
			if (user == null) throw new UserNotFoundException();
			if (!await _userManager.CheckPasswordAsync(user, request.Password)) throw new FailedLoginException();
			return AppResponseDto<TokenDto>.Success(
				await _authenticationService.CreateTokenByUserAsync(user)
				);
		}
	}
}
