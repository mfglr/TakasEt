using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessagesAsReceivedDto : IRequest<IAppResponseDto>
    {
        public List<string> Ids { get; set; }
        public long ReceivedDate { get; set; }
    }
}
