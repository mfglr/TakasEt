namespace Models.Dtos
{
	public class MessageResponseDto : BaseResponseDto
	{
		public int? SenderId { get; set; }
		public int? ReceiverId { get; set; }
		public int? GroupId { get; set; }
		public string Content { get; set; }
		public int Status { get; set; }
	}
}
