﻿using MediatR;

namespace Models.DomainEventModels
{
	public class EntityDomainEvent : IEntityDomainEvent
	{
		private readonly List<INotification> _domainEvents = new ();
		public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearAllDomainEvents() => _domainEvents.Clear();
        public bool AnyDomainEvents() => _domainEvents.Any();
        public void PublishAllDomainEvents(IPublisher publisher) => _domainEvents.ForEach( domainEvent => publisher.Publish(domainEvent) );
		
	}
}
