using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkNewMessagesAsReceivedDto : IRequest<IAppResponseDto>
    {
        public List<string> Ids { get; set; }
        public long ReceivedDate { get; set; }
    }
}
