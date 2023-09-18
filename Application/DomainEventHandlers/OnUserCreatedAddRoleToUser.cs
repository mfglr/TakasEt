using Application.DomainEventModels;
using Application.Entities;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using MediatR;

namespace Application.DomainEventHandlers
{
	public class OnUserCreatedAddRoleToUser : INotificationHandler<UserDomainEvent>
	{

		private readonly IRepository<UserRole> _userRoles;
		private readonly IRoleService _roleService;

		public OnUserCreatedAddRoleToUser(IRepository<UserRole> userRoles, IRoleService roleService)
		{
			_userRoles = userRoles;
			_roleService = roleService;
		}

		public async Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _userRoles.DbSet.AddAsync(new UserRole(notification.User.Id, _roleService.User.Id));
		}
	}
}
