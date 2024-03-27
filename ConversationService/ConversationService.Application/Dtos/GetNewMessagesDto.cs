using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class GetNewMessagesDto : IRequest<IAppResponseDto>
    {
        public int Take { get; set; }
        public long LastValue { get; set; }
        public bool IsDescending { get; set; }

        public GetNewMessagesDto()
        {
            
        }
    }
}

