using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class GetNewMessagesDto : IRequest<IAppResponseDto>
    {
        public GetNewMessagesDto()
        {
        }
    }
}

