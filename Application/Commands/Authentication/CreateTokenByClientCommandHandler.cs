using Application.Dtos;
using Application.Interfaces.Services;
using MediatR;

namespace Application.Commands.Authentication
{
	public class CreateTokenByClientCommandHandler : IRequestHandler<ClientLoginDto, AppResponseDto>
	{

		private readonly IAuthenticationService _authenticationService;

		public CreateTokenByClientCommandHandler(IAuthenticationService authenticationService)
		{
			_authenticationService = authenticationService;
		}

		public Task<AppResponseDto> Handle(ClientLoginDto request, CancellationToken cancellationToken)
		{
			return Task.FromResult(
				 AppResponseDto.Success(
					 _authenticationService.CreateTokenByClient(request)
					 )
				);
		}

	}
}
