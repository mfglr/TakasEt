using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessageAsViewedDto : IRequest<IAppResponseDto>
    {
        public Guid ReceiverId { get; set; }
        public Guid SenderId { get; set; }
        public string MessageId { get; set; }
    }
}
