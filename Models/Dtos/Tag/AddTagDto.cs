using MediatR;

namespace Models.Dtos
{
	public class AddTagDto : IRequest<AppResponseDto>
	{
		public string? Name { get; private set; }

        public AddTagDto(string name)
        {
            Name = name;
        }
    }
}
