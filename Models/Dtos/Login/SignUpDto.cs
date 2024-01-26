using MediatR;

namespace Models.Dtos
{
	public class SignUpDto : IRequest<AppResponseDto>
    {
        public string UserName { get; private set; }
        public string Password { get; private set; }
        public string PasswordConfirmation { get; private set; }
        public string Email { get; private set; }

        public SignUpDto(string userName, string password, string passwordConfirmation, string email)
        {
            UserName = userName;
            Password = password;
            PasswordConfirmation = passwordConfirmation;
            Email = email;
        }
    }
}
