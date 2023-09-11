using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands.Authentication
{
	public class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<RefreshTokenDto,AppResponseDto<TokenDto>>
	{

		private readonly IAuthenticationService _authenticationService;

		public CreateTokenByRefreshTokenCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<AppResponseDto<TokenDto>> Handle(RefreshTokenDto request, CancellationToken cancellationToken)
		{

			return AppResponseDto<TokenDto>.Success(
				await _authenticationService.CreateAccessTokenByRefreshTokenAsync(request.RefreshToken)
				);
		}
	}
}
