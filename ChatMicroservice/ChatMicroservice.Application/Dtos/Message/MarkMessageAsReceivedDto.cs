using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Message
{
	public class MarkMessageAsReceivedDto : IRequest<AppResponseDto>
	{
		public int MessageId { get; set; }
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
	}
}
