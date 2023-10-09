using Application.Configurations;
using Application.DomainEventModels;
using Application.Entities;
using Application.Interfaces.Repositories;
using MediatR;

namespace Application.DomainEventHandlers
{
	public class OnUserCreatedAddRoleToUser : INotificationHandler<UserDomainEvent>
	{

		private readonly IRepository<UserRole> _userRoles;
		private readonly Configuration _configuration;

		public OnUserCreatedAddRoleToUser(IRepository<UserRole> userRoles, Configuration configuration)
		{
			_userRoles = userRoles;
			_configuration = configuration;
		}

		public async Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _userRoles.DbSet.AddAsync(new UserRole(notification.User.Id, Guid.Parse(_configuration.Roles.User.Id)));
		}
	}
}
