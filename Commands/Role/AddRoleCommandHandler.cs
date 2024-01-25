using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
	public class AddRoleCommandHandler : IRequestHandler<AddRoleDto, AppResponseDto>
	{
		private readonly IWriteRepository<Role> _roles;

		public AddRoleCommandHandler(IWriteRepository<Role> roles)
		{
			_roles = roles;
		}

		public async Task<AppResponseDto> Handle(AddRoleDto request, CancellationToken cancellationToken)
		{
			var role = new Role(request.Name);
			return AppResponseDto.Success(await _roles.CreateAsync(role, cancellationToken));
		}
	}
}
