using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class DisconnectDto : IRequest<IAppResponseDto>
    {
    }
}
