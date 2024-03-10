using SharedLibrary.Dtos;

namespace ConversationService.Application.Dtos
{
    public class ConversationResponseDto
    {
        public Guid UserId { get; set; }
        public UserResponseDto? User { get; set; }
        public IEnumerable<MessageResponseDto> Messages { get; set; }
    }
}
