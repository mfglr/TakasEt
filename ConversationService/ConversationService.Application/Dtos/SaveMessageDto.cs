using ConversationService.Application.Dtos;
using MediatR;

namespace ConversationService.SignalR.Dtos
{
    public class SaveMessageDto : IRequest<MessageResponseDto>
    {
        public string Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public long SendDate { get; set; }
    }
}
