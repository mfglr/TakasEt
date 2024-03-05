using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class LikeMessageDto : IRequest<IAppResponseDto>
    {
        public Guid ConversationId { get; set; }
        public string MessageId { get; set; }
    }
}
