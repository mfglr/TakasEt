using MediatR;

namespace Models.Dtos
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
