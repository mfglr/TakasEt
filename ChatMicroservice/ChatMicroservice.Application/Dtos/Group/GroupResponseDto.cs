using ChatMicroservice.Application.Dtos.Group;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class GroupResponseDto : BaseResponseDto
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public int NumberOfUnviewedMessages { get; set; }
	}
}
