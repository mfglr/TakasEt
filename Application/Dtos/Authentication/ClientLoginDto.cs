using MediatR;

namespace Application.Dtos
{
    public class ClientLoginDto : IRequest<AppResponseDto<ClientTokenDto>>
    {
        public string Id { get; private set; }
        public string Secret { get; private set; }

		public ClientLoginDto(string id, string secret)
		{
			Id = id;
			Secret = secret;
		}
	}
}
