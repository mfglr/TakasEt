using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands.Authentication
{
	public class CreateTokenByClientCommandHandler : IRequestHandler<ClientLoginDto, ClientTokenDto>
	{

		private readonly IAuthenticationService _authenticationService;

		public CreateTokenByClientCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public Task<ClientTokenDto> Handle(ClientLoginDto request, CancellationToken cancellationToken)
		{
			return Task.FromResult<ClientTokenDto>(_authenticationService.CreateTokenByClient(request));
		}

	}
}
