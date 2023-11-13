using MediatR;

namespace Application.Dtos
{
	public class AddCategory : IRequest<AppResponseDto>
	{
		public string Name { get; private set; }

		public AddCategory(string name)
		{
			Name = name;
		}
	}
}
