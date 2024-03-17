using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class UserConnectionResponseDto : BaseResponseDto<Guid>
    {
        public bool IsConnected { get; set; }
        public string ConnectionId { get; set; }
    }
}
