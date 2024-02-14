using MediatR;
using SharedLibrary.Dtos;

namespace AuthService.Api.Models.Dtos
{
    public class SignUpByEmailDto : IRequest<AppResponseDto>
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
