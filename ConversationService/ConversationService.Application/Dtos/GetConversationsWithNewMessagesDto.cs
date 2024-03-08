using MediatR;
using Microsoft.AspNetCore.Http;
using SharedLibrary.Dtos;
using SharedLibrary.Extentions;

namespace ConversationService.Application.Dtos
{
    public class GetConversationsWithNewMessagesDto : IRequest<IAppResponseDto>
    {
        public DateTime? TimeStamp { get; private set; }

        public GetConversationsWithNewMessagesDto(IQueryCollection collection)
        {
            TimeStamp = collection.ReadDateTime("timeStamp");
        }
    }
}

