using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Group
{
	public class ApproveRequestToJoinGroupDto : IRequest<AppResponseDto>
	{
		public int GroupId { get; set; }
		public int IdOfUserWhoWantsToJoin { get; set; }
		public int IdOfUserApprovingRequest { get; set; }
	}
}
