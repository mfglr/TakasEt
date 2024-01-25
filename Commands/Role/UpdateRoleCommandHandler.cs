using Application.Dtos;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Commands
{
    public class UpdateRoleCommandHandler : IRequestHandler<UpdateRoleDto, AppResponseDto>
	{
		private readonly IReadRepository<Role> _roles;

		public UpdateRoleCommandHandler(IReadRepository<Role> roles)
		{
			_roles = roles;
		}

		public async Task<AppResponseDto> Handle(UpdateRoleDto request, CancellationToken cancellationToken)
		{
			var role = await _roles.GetByIdAsync((int)request.Id!,cancellationToken);
			role!.Update(request.Name!);
			return AppResponseDto.Success();
		}
	}
}
