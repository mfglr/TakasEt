using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class GetGroupsWithUnviewedMessagesByUserIdDto : IPage, IRequest<AppResponseDto>
	{
		public int UserId { get; set; }
		public int? Take { get; set; }
		public int? LastId { get; set; }
	}
}
