using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class LeaveGroupDto : IRequest<AppResponseDto>
	{
		public Guid UserId { get; set; }
		public Guid GroupId { get; set; }
	}
}
