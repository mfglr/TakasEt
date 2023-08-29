using Application.Interfaces.Services;

namespace Application.DomainEventHandlers
{
	public class OnUserConfirmEmailCreateCreditDomainEventHandler
	{
		private readonly ISmtpService service;
		private readonly  

		public OnUserConfirmEmailCreateCreditDomainEventHandler(ISmtpService service)
		{
			this.service = service;
		}

	}
}
