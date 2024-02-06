using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class SaveMessageDto : IRequest<AppResponseDto>
	{
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
		public string Content { get; set; }
		public List<MessageImageRequestDto> MessageImages { get; set; }
	}
}
