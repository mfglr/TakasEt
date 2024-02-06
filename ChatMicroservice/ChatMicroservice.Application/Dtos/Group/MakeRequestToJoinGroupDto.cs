using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class MakeRequestToJoinGroupDto : IRequest<AppResponseDto>
	{
		public int GroupId { get; set; }
		public int UserId { get; set; }
	}
}
