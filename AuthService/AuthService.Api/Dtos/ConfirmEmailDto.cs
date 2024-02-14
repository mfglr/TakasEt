using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Api.Dtos
{
    public class ConfirmEmailDto : IRequest<AppResponseDto>
    {
        public string Token { get; set; }
        public string UserId { get; set; }
    }
}
