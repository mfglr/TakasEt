using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessageAsReceivedDto : IRequest<IAppResponseDto>
    {
        public string MessageId { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
