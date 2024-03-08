using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkAllNewMessagesAsReceivedDto : IRequest<IAppResponseDto>
    {
        public DateTime ReceivedDate { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}
