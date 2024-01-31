using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
	public class AddRoleCommandHandler : IRequestHandler<AddRoleDto, AppResponseDto>
	{
		private readonly IRepository<Role> _roles;

		public AddRoleCommandHandler(IRepository<Role> roles)
		{
			_roles = roles;
		}

		public async Task<AppResponseDto> Handle(AddRoleDto request, CancellationToken cancellationToken)
		{
			var role = new Role(request.Name);
			var entity = (await _roles.DbSet.AddAsync(role, cancellationToken)).Entity;
			return AppResponseDto.Success(entity);
		}
	}
}
