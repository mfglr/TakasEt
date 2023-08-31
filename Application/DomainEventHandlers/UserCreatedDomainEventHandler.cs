using Application.DomainEventModels;
using Application.Interfaces.Services;
using MediatR;

namespace Application.DomainEventHandlers
{
	public class UserCreatedDomainEventHandler : INotificationHandler<UserDomainEvent>
	{

		private readonly ISmtpService _smtpService;

		public UserCreatedDomainEventHandler(ISmtpService smtpService)
		{
			_smtpService = smtpService;
		}

		public async Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
		{
			
			await _smtpService.SendEmailToUserThatAccountHasBeenCreated(notification.User);
		}
	}
}
