using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class SaveGroupMessageDto : IRequest<AppResponseDto>
	{
		public int SenderId { get; set; }
		public int GroupId { get; set; }
		public string Content { get; set; }
		public List<MessageImageRequestDto> MessageImages { get; set; }
	}
}
