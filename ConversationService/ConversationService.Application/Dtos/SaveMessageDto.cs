using ConversationService.Application.Dtos;
using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.SignalR.Dtos
{
    public class SaveMessageDto : IRequest<IAppResponseDto>
    {
        public string Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
        public long SendDate { get; set; }
    }
}
