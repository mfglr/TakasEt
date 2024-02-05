using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos.Group
{
	public class ApproveRequestToJoinGroupDto : IRequest<AppResponseDto>
	{
		public Guid GroupId { get; set; }
		public Guid IdOfUserWhoWantsToJoin { get; set; }
		public Guid IdOfUserApprovingRequest { get; set; }
	}
}
