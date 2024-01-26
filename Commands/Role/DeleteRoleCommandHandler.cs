using Application.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleDto, AppResponseDto>
	{
		private readonly IWriteRepository<Role> _roles;

		public DeleteRoleCommandHandler(IWriteRepository<Role> roles)
		{
			_roles = roles;
		}

		public async Task<AppResponseDto> Handle(DeleteRoleDto request, CancellationToken cancellationToken)
		{
			await _roles.DeleteAsync(request.Id, cancellationToken);
			return AppResponseDto.Success();
		}
	}
}
