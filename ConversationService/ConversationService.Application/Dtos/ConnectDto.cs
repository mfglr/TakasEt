using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class ConnectDto : IRequest<IAppResponseDto>
    {
        public string ConnectionId { get; set; }
    }
}
