using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class UserConnectionResponseDto : BaseResponseDto<Guid>
    {
        public bool IsPrivateConnection { get; set; }
        public string ConnectionId { get; set; }
    }
}
