using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class IsBlockerOrBlockedDto : IRequest<IAppResponseDto>
    {
        public string UserId { get; set; }
    }
}
