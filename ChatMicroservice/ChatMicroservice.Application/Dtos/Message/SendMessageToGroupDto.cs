using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Message
{
	public class SendMessageToGroupDto : IRequest<AppResponseDto>
	{
		public Guid SenderId { get; set; }
		public Guid GroupId { get; set; }
		public string Content { get; set; }
	}
}
