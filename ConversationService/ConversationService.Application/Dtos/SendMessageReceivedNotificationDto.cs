using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class SendMessageReceivedNotificationDto : IRequest<IAppResponseDto>
    {
        public Guid ConversationId { get; set; }
        public Guid ReceiverId { get; set; }
        public string MessageId { get; set; }
    }
}
