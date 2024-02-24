using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class IsBlockedDto : IRequest<IAppResponseDto>
    {
        public string UserId { get; set; }
    }
}
