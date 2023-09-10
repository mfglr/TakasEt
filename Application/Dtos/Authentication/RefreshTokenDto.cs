using MediatR;

namespace Application.Dtos
{
	public class RefreshTokenDto : IRequest<TokenDto>
	{
        public string RefreshToken { get; private set; }
        public RefreshTokenDto(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
