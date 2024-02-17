using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class ConfirmEmailDto : IRequest<AppResponseDto>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
