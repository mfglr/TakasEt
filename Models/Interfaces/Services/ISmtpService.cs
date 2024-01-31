using Models.Entities;

namespace Models.Interfaces.Services
{
	public interface ISmtpService
	{
		Task SendEmailConfirmationMailToUser(User user);
	}
}
