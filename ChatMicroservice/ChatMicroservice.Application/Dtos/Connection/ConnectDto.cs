using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class ConnectDto : IRequest<AppResponseDto>
	{
		public int UserId { get; set; }
		public string ConnectionId { get; set; }
	}
}
