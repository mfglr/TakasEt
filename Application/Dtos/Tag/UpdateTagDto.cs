using MediatR;

namespace Application.Dtos
{
	public class UpdateTagDto : IRequest<AppResponseDto>
	{
		public int? Id { get; private set; }
		public string? Name { get; private set; }

		public UpdateTagDto(int? id, string? name)
		{
			Id = id;
			Name = name;
		}
	}
}
