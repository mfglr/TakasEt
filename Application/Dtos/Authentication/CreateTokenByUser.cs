using MediatR;

namespace Application.Dtos
{
	public class CreateTokenByUser : IRequest<AppResponseDto>
	{
        public string Email { get; private set; }
        public string Password { get; private set; }

		public CreateTokenByUser(string email, string password)
		{
			Email = email;
			Password = password;
		}

	}
}
