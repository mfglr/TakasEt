using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class GetConversationsThatHaveNewMessagesDto : IRequest<IAppResponseDto>
    {
        public GetConversationsThatHaveNewMessagesDto()
        {
        }
    }
}
