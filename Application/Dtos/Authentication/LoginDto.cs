using MediatR;

namespace Application.Dtos
{
    public class LoginDto : IRequest<AppResponseDto<TokenDto>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
