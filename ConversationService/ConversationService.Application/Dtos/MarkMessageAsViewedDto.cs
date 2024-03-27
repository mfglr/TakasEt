using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MarkMessageAsViewedDto : IRequest
    {
        public string MessageId { get; set; }
        public long ViewedDate { get; set; }
    }
}
