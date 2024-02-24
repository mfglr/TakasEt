using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class MessageResponseDto : BaseResponseDto<Guid>
    {
        public Guid SenderId { get; set; }
        public string Content { get; set; }
    }
}
