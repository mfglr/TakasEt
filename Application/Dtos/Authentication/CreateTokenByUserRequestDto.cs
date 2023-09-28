using MediatR;

namespace Application.Dtos.Authentication
{
	public class CreateTokenByUserRequestDto : IRequest<AppResponseDto>
	{
        public string Email { get; private set; }
        public string Password { get; private set; }

		public CreateTokenByUserRequestDto(string email, string password)
		{
			Email = email;
			Password = password;
		}

	}
}
