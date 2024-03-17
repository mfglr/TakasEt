using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessagesAsViewedDto : IRequest<IAppResponseDto>
    {
        public List<string> Ids { get; set; }
        public long ViewedDate { get; set; }
    }
}
