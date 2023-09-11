using MediatR;

namespace Application.Dtos
{
	public class RefreshTokenDto : IRequest<AppResponseDto<TokenDto>>
	{
        public string RefreshToken { get; private set; }
        public RefreshTokenDto(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
