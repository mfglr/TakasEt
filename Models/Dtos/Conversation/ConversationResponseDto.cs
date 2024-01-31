namespace Models.Dtos
{
	public class ConversationResponseDto : BaseResponseDto
	{
		public int SenderId { get; set; }
		public int ReceiverId { get; set; }
	}
}
