using MediatR;

namespace Application.Dtos
{
    public class DeleteRoleDto : IRequest<AppResponseDto>
    {
        public int Id { get; private set; }

        public DeleteRoleDto(int id)
        {
            Id = id;
        }
    }
}
