namespace ConversationService.Application.Dtos
{
    public class MarkMessagesAsReceivedDto
    {
        public Guid UserId { get; set; }
        public DateTime ReceivedDate { get; set; }
    }
}
