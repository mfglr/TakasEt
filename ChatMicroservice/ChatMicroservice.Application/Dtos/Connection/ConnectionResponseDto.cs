using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class ConnectionResponseDto : BaseResponseDto
	{
		public Guid UserId { get; set; }
		public string ConnectionId { get; set; }
		public bool Connected { get; set; }
	}
}
