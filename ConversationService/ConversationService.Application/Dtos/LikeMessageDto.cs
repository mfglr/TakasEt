using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class LikeMessageDto : IRequest<IAppResponseDto>
    {
        public string MessageId { get; set; }
    }
}
