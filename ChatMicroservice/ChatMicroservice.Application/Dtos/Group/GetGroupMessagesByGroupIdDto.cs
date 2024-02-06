using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class GetGroupMessagesByGroupIdDto : IPage, IRequest<AppResponseDto>
	{
		public int GroupId { get; set; }
		public int? UserId { get; set; }
		public int? Take { get; set; }
		public int? LastId { get; set; }
	}
}
