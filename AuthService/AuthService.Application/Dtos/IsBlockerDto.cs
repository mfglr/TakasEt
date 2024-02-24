using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class IsBlockerDto : IRequest<IAppResponseDto>
    {
        public string UserId { get; set; }
    }
}
