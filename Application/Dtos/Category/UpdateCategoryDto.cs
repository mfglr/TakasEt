using MediatR;

namespace Application.Dtos
{
	public class UpdateCategoryDto : IRequest<AppResponseDto>
	{
		public int? Id { get; private set; }
		public string? Name { get; private set; }
	}
}
