using Application.DomainEventModels;
using Application.Interfaces.Services;
using MediatR;

namespace Application.DomainEventHandlers
{
	public class OnUserCreatedSendEmailConfirmationMailToUserDomainEventHandler : INotificationHandler<UserDomainEvent>
	{

		private readonly ISmtpService _smtpService;
		public OnUserCreatedSendEmailConfirmationMailToUserDomainEventHandler(ISmtpService smtpService)
		{
			_smtpService = smtpService;
		}

		public async Task Handle(UserDomainEvent notification, CancellationToken cancellationToken)
		{
			await _smtpService.SendEmailConfirmationMailToUser(notification.User);
		}
	}
}
