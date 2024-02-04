using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class DisconnectDto : IRequest<AppResponseDto>
	{
		public Guid UserId { get; set; }
	}
}
