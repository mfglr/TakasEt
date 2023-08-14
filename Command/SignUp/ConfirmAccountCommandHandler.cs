using Application.Dtos;
using Application.Dtos.SignUp;
using MediatR;

namespace Command.SignUp
{
	public class ConfirmAccountCommandHandler : IRequestHandler<ConfirmAccountCommandRequestDto, NoContentResponseDto>
	{
		public Task<NoContentResponseDto> Handle(ConfirmAccountCommandRequestDto request, CancellationToken cancellationToken)
		{
			
		}
	}
}
