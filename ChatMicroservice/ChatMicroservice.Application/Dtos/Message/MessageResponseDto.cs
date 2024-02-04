using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class MessageResponseDto : BaseResponseDto
	{
		public Guid SenderId { get; set; }
		public string Content { get; set; }
		public int NumberOfImages { get; set; }
		public List<MessageImageResponseDto> MessageImages { get; set; }
	}
}
