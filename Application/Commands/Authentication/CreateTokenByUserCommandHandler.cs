using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands
{
	public class CreateTokenByUserCommandHandler : IRequestHandler<LoginDto, TokenDto>
	{

		private readonly IAuthenticationService _authenticationService;

		public CreateTokenByUserCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public async Task<TokenDto> Handle(LoginDto request, CancellationToken cancellationToken)
		{
			return await _authenticationService.CreateTokenByUserAsync(request);
		}
	}
}
