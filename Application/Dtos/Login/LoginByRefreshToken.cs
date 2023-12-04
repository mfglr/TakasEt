using MediatR;

namespace Application.Dtos
{
	public class LoginByRefreshToken : IRequest<AppResponseDto>
	{
        public string RefreshToken { get; private set; }

		public LoginByRefreshToken(string refreshToken)
		{
			RefreshToken = refreshToken;
		}
	}
}
