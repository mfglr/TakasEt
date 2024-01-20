using MediatR;

namespace Application.Dtos
{
	public class AddCategoryDto : IRequest<AppResponseDto>
	{
		public string Name { get; private set; }

		public AddCategoryDto(string name)
		{
			Name = name;
		}
	}
}
