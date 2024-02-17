using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class LoginByRefreshTokenDto : IRequest<AppResponseDto>
    {
        public string UserId { get; set; }
        public string Token { get; set; }
    }
}
