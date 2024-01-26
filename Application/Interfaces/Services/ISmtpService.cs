using Models.Entities;

namespace Application.Interfaces.Services
{
	public interface ISmtpService
	{
		Task SendEmailConfirmationMailToUser(User user);
	}
}
