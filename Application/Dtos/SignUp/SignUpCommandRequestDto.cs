using MediatR;

namespace Application.Dtos.SignUp
{
	public class SignUpCommandRequestDto : IRequest<SignUpCommandResponseDto>
	{
		public string UserName { get; private set; }
		public string Password { get; private set; }
		public string PasswordConfirmation { get; private set; }
		public string Email { get; private set; }

		public SignUpCommandRequestDto(string userName, string password, string passwordConfirmation, string email)
		{
			UserName = userName;
			Password = password;
			PasswordConfirmation = passwordConfirmation;
			Email = email;
		}
	}
}
