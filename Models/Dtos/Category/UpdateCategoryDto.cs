using MediatR;

namespace Models.Dtos
{
	public class UpdateCategoryDto : IRequest<AppResponseDto>
	{
		public int? Id { get; private set; }
		public string? Name { get; private set; }

		public UpdateCategoryDto(int? id, string? name)
		{
			Id = id;
			Name = name;
		}

	}
}
