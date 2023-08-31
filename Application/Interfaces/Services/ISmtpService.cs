using Application.Entities;

namespace Application.Interfaces.Services
{
	public interface ISmtpService
	{
		Task SendEmailConfirmationMailToUser(User user);
		Task SendMailtoUserThatCreditHasBeenCreated(User user);
	}
}
