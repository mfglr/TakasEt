using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands
{
	public class CreateTokenByUserCommandHandler : IRequestHandler<LoginDto, AppResponseDto<TokenDto>>
	{

		private readonly IAuthenticationService _authenticationService;

		public CreateTokenByUserCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<AppResponseDto<TokenDto>> Handle(LoginDto request, CancellationToken cancellationToken)
		{
			return AppResponseDto<TokenDto>.Success(
				await _authenticationService.CreateTokenByUserAsync(request)
				);
		}
	}
}
