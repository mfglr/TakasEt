using Application.Dtos;
using MediatR;

namespace Dto.SignUp
{
	public class SignUpCommandRequestDto : IRequest<CustomResponseDto<SignUpCommandResponseDto>>
	{
		public string UserName { get; private set; }
		public string Password { get; private set; }
		public string PasswordConfirmation { get; private set; }
		public string? Email { get; private set; }
		public string? Phone { get; private set; }
	}
}
