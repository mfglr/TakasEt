using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands.Authentication
{
	public class CreateTokenByRefreshTokenCommandHandler : IRequestHandler<RefreshTokenDto, TokenDto>
	{

		private readonly IAuthenticationService _authenticationService;

		public CreateTokenByRefreshTokenCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<TokenDto> Handle(RefreshTokenDto request, CancellationToken cancellationToken)
		{
			return await _authenticationService.CreateAccessTokenByRefreshTokenAsync(request.RefreshToken);
		}
	}
}
