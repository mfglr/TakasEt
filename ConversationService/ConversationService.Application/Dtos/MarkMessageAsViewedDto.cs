using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessageAsViewedDto : IRequest<IAppResponseDto>
    {
        public string MessageId { get; set; }
        public DateTime ViewedDate { get; set; }
    }
}
