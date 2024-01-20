using MediatR;

namespace Application.Dtos
{
	public class LoginByRefreshTokenDto : IRequest<AppResponseDto>
	{
        public string RefreshToken { get; private set; }

		public LoginByRefreshTokenDto(string refreshToken)
		{
			RefreshToken = refreshToken;
		}
	}
}
