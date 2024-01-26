using MediatR;

namespace Models.Dtos
{
	public class AddConversationDto : IRequest<AppResponseDto>
	{
		public string FirstMessageContent { get; private set; }
		public int SenderId { get; private set; }
		public int ReceiverId { get; private set; }
		
		public AddConversationDto(int senderId,int receiverId,string firstMessageContent)
		{
			SenderId = senderId;
			ReceiverId = receiverId;
			FirstMessageContent = firstMessageContent;
		}
	}
}
