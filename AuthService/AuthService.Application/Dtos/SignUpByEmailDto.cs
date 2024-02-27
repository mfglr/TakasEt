using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Application.Dtos
{
    public class SignUpByEmailDto : IRequest<IAppResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
