using MediatR;
using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class GetNewMessagesDto : IRequest<IAppResponseDto>, IPage<DateTime>
    {
        public int Take { get; set; }
        public DateTime LastValue { get; set; }
        public bool IsDescending { get; set; }

        public GetNewMessagesDto()
        {
            
        }
    }
}

