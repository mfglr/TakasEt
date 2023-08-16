using Application.DomainEventModels;
using Application.Interfaces.Services;
using MediatR;

namespace Application.DomainEventHandlers
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
