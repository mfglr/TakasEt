using MediatR;

namespace Application.Dtos
{
    public class UpdateRoleDto : IRequest<AppResponseDto>
    {
        public int? Id { get; private set; }
        public string? Name { get; private set; }

        public UpdateRoleDto(int? id, string? name)
        {
            Id = id;
            Name = name;
        }
    }
}
