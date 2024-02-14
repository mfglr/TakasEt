using AuthService.Api.Dtos;
using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Api.Commands
{
    public class ConfirmEmailCommandHandler : IRequestHandler<ConfirmEmailDto, AppResponseDto>
    {


        public Task<AppResponseDto> Handle(ConfirmEmailDto request, CancellationToken cancellationToken)
        {

            return Task.FromResult( AppResponseDto.Success());
        }
    }
}
