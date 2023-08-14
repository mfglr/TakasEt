
using Application.Entities;

namespace Application.Interfaces.Services
{
	public interface ISmtpService
	{
		Task SendEmailToUserThatAccountHasBeenCreated(User user); 
	}
}
