using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessagesAsViewedDto : IRequest<IAppResponseDto>
    {
        public Guid UserId { get; set; }
        public DateTime ViewedDate { get; set; }
    }
}
