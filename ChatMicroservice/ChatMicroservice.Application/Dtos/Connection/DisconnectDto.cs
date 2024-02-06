using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class DisconnectDto : IRequest<AppResponseDto>
	{
		public int UserId { get; set; }
	}
}
