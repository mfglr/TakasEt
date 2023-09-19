using MediatR;

namespace Application.Dtos
{
	public class RefreshTokenDto : IRequest<AppResponseDto>
	{
        public string RefreshToken { get; private set; }
        public RefreshTokenDto(string refreshToken)
        {
            RefreshToken = refreshToken;
        }
    }
}
