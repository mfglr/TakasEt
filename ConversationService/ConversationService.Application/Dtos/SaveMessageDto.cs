using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.SignalR.Dtos
{
    public class SaveMessageDto : IRequest<IAppResponseDto>
    {
        public Guid ReceiverId { get; set; }
        public string Content { get; set; }
    }
}
