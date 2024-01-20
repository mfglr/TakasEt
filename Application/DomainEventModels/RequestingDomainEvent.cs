using Application.Entities;
using MediatR;

namespace Application.DomainEventModels
{
	public class RequestingDomainEvent : INotification
	{
		public Requesting Requesting { get; private set; }

		public RequestingDomainEvent(Requesting requesting)
		{
			Requesting = requesting;
		}
	}
}
