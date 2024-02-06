using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Group
{
	public class RemoveUserFromGroupDto : IRequest<AppResponseDto>
	{
		public int GrupId { get; set; }
		public int RemoverId { get; set; }
		public int UserId { get; set; }
	}
}
