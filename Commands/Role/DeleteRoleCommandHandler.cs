using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class DeleteRoleCommandHandler : IRequestHandler<DeleteRoleDto, AppResponseDto>
	{
		private readonly IRepository<Role> _roles;

		public DeleteRoleCommandHandler(IRepository<Role> roles)
		{
			_roles = roles;
		}

		public async Task<AppResponseDto> Handle(DeleteRoleDto request, CancellationToken cancellationToken)
		{
			var role = await _roles
				.DbSet
				.FindAsync(request.Id, cancellationToken);
			_roles.DbSet.Remove(role!);
			return AppResponseDto.Success();
		}
	}
}
