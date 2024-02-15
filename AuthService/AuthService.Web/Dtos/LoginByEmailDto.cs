using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Web.Dtos
{
    public class LoginByEmailDto : IRequest<AppResponseDto>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
