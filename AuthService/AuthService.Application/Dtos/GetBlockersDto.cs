using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class GetBlockersDto : IRequest<IAppResponseDto>
    {
    }
}
