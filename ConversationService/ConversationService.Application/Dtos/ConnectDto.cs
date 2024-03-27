using MediatR;

namespace ConversationService.Application.Dtos
{
    public class ConnectDto : IRequest
    {
        public string ConnectionId { get; set; }
    }
}
