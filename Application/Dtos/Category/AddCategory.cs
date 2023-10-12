using MediatR;

namespace Application.Dtos
{
	public class AddCategory : IRequest<AppResponseDto>
	{
		public string Name { get; private set; }
		public string Description { get; private set; }

		public AddCategory(string name, string description)
		{
			Name = name;
			Description = description;
		}
	}
}
