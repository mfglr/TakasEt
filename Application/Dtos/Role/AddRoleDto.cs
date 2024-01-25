using MediatR;

namespace Application.Dtos
{
	public class AddRoleDto : IRequest<AppResponseDto>
	{
		public string Name { get; private set; }

        public AddRoleDto(string name)
        {
            Name = name;
        }
    }
}
