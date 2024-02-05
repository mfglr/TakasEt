using MediatR;
using SharedLibrary.Dtos;

namespace ChatMicroservice.Application.Dtos
{
	public class CreateGroupDto : IRequest<AppResponseDto>
	{
		public Guid UserId { get; set; }
		public string Name { get; set; }
		public string Description { get; set; }
		public List<Guid> Users { get; set; }
	}
}
