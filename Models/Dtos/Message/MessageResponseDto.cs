namespace Models.Dtos
{
	public class MessageResponseDto
	{
		public int UserId { get; private set; }
		public string Content { get; private set; }
		public string ConnectionId { get; private set; }

		public MessageResponseDto(int userId, string content, string connectionId)
		{
			UserId = userId;
			Content = content;
			ConnectionId = connectionId;
		}
	}
}
