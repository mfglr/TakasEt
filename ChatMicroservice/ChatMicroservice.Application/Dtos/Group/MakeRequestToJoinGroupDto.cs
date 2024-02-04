using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class MakeRequestToJoinGroupDto : IRequest<AppResponseDto>
	{
		public Guid GroupId { get; set; }
		public Guid UserId { get; set; }
	}
}
