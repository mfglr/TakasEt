using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class ConfirmEmailDto : IRequest<IAppResponseDto>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
