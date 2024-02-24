using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class LoginByEmailDto : IRequest<IAppResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
