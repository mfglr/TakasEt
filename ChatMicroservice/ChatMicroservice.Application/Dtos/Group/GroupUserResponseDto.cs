using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Group
{
	public class GroupUserResponseDto : BaseResponseDto
	{
		public Guid UserId { get; set; }
	}
}
