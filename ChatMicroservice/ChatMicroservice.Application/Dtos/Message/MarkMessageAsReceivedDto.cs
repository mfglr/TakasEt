using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Message
{
	public class MarkMessageAsReceivedDto : IRequest<AppResponseDto>
	{
		public Guid MessageId { get; set; }
		public Guid SenderId { get; set; }
		public Guid ReceiverId { get; set; }
	}
}
