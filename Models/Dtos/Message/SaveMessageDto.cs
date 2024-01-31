using MediatR;

namespace Models.Dtos
{
	public class SaveMessageDto : IRequest<AppResponseDto>
	{
		public int? SenderId { get; private set; }
		public int? ReceiverId { get; private set; }
		public string? Content { get; private set; }

		public SaveMessageDto(int? senderId, int? receiverId, string? content)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
			Content = content;
		}
	}
}
