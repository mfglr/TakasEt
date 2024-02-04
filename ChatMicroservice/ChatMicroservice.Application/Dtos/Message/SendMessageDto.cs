using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class SendMessageDto : IRequest<AppResponseDto>
	{
		public Guid SenderId { get; set; }
		public Guid ReceiverId { get; set; }
		public string Content { get; set; }
	}
}
