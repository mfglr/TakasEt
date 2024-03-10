using MediatR;
using Microsoft.AspNetCore.Http;
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

