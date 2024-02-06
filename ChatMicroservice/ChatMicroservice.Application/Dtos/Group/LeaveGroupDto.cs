using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class LeaveGroupDto : IRequest<AppResponseDto>
	{
		public int UserId { get; set; }
		public int GroupId { get; set; }
	}
}
