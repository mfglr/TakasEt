using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class MessageResponseDto : BaseResponseDto
	{
		public int? GroupId { get; set; }
		public int? ConversationId { get; set; }
		public int SenderId { get; set; }
		public string Content { get; set; }
		public int NumberOfImages { get; set; }
		public string State { get; set; }
		public List<MessageImageResponseDto> MessageImages { get; set; }
	}
}
