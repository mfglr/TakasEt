using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Group
{
	public class RemoveUserFromGroupDto : IRequest<AppResponseDto>
	{
		public Guid GrupId { get; set; }
		public Guid RemoverId { get; set; }
		public Guid UserId { get; set; }
	}
}
