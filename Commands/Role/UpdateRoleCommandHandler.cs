using Models.Interfaces.Repositories;
using MediatR;
using Models.Dtos;
using Models.Entities;

namespace Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleDto, AppResponseDto>
	{
		private readonly IRepository<Role> _roles;

		public UpdateRoleCommandHandler(IRepository<Role> roles)
		{
			_roles = roles;
		}

		public async Task<AppResponseDto> Handle(UpdateRoleDto request, CancellationToken cancellationToken)
		{
			var role = await _roles
				.DbSet
				.FindAsync((int)request.Id!,cancellationToken);
			role!.Update(request.Name!);
			return AppResponseDto.Success();
		}
	}
}
