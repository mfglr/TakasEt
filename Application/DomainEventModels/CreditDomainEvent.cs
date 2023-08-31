using Application.Entities;
using MediatR;

namespace Application.DomainEventModels
{
	public class CreditDomainEvent : INotification
	{
        public Credit Credit { get; private set; }
		public CreditDomainEvent(Credit credit) {
			Credit = credit;
		}
    }
}
