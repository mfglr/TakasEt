using Application.DomainEventModels;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Application.Entities
{
	public class Role : IdentityRole<Guid>, IEntity, IEntityDomainEvent
	{
		private List<INotification> _domainEvents = new List<INotification>();
		public Guid Id { get; private set; }
		public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

		public void SetId()
		{
			Id = Guid.NewGuid();
		}

		public void SetCreatedDate()
		{
			CreatedDate = DateTime.UtcNow;
		}
	
		public void SetUpdatedDate()
		{
			UpdatedDate = DateTime.UtcNow;
		}


		public void AddDomainEvent(INotification domainEvent)
		{
			_domainEvents.Add(domainEvent);
		}
		public void PublishAllDomainEvents(IPublisher publisher)
		{
			_domainEvents.ForEach(
				domainEvent =>
				{
					publisher.Publish(domainEvent);
				}
			);
		}
		public void ClearAllDomainEvents()
		{
			_domainEvents.Clear();
		}
		public bool AnyDomainEvents()
		{
			var events = _domainEvents;
			var data = _domainEvents.Any();
			return data;
		}

	}
}
