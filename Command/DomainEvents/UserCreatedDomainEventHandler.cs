using Application.DomainEvents;
using Application.Interfaces.Services;
using MediatR;
using System.Security.Principal;

namespace Command.DomainEvents
{
	public class UserCreatedDomainEventHandler : INotificationHandler<UserCreatedDomainEvent>
	{

		private readonly ISmtpService _smtpService;

		public UserCreatedDomainEventHandler(ISmtpService smtpService)
		{
			_smtpService = smtpService;
		}

		public async Task Handle(UserCreatedDomainEvent notification, CancellationToken cancellationToken)
		{
			await _smtpService.SendEmailToUserThatAccountHasBeenCreated(notification.User);
		}
	}
}
