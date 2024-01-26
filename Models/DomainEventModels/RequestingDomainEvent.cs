using MediatR;
using Models.Entities;

namespace Models.DomainEventModels
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
