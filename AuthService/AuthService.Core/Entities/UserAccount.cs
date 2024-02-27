using MediatR;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Entities;
using SharedLibrary.Events;
using SharedLibrary.Exceptions;
using SharedLibrary.Extentions;
using SharedLibrary.Services;
using System.Net;

namespace AuthService.Core.Entities
{
    public class UserAccount :
        IdentityUser<string>,
        IEntity<string>,
        IBlockableByUsers<Blocking, string>,
        IAggregateRoot
    {
        
        public UserAccount(string email)
        {
            UserName = $"{email.GetFirstSectionOfEmail()}_{Guid.NewGuid()}";
            Email = email;
        }


        public bool IsPrivateAccount { get; private set; }
        public void HideAccount() => IsPrivateAccount = true;
        public void MakeAccountVisible() => IsPrivateAccount = false;

        //IEntity
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public void SetCreatedDate() => CreatedDate = DateTime.Now;
        public void SetUpdatedDate() => UpdatedDate = DateTime.Now;
        public void SetId() => Id = Guid.NewGuid().ToString();

        //IRemovable
        public bool IsRemoved { get; protected set; }
        public DateTime? RemovedDate { get; protected set; }
        public void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;
        }
        public void Reinsert()
        {
            IsRemoved = false;
            RemovedDate = null;
        }

        //IDomainEventContainer
        private readonly List<INotification> _domainEvents = new();
        public void AddDomainEvent(INotification domainEvent) => _domainEvents.Add(domainEvent);
        public void ClearAllDomainEvents() => _domainEvents.Clear();
        public bool AnyDomainEvents() => _domainEvents.Any();
        public async Task PublishAllDomainEventsAsync(IPublisher publisher, CancellationToken cancellationToken)
        {
            foreach (var domainEvent in _domainEvents)
                await publisher.Publish(domainEvent, cancellationToken);
        }

        //IIntegrationEventsContainer
        private readonly List<IntegrationEvent> events = new();
        public bool AnyIntegrationEvent() => events.Any();
        public void AddIntegrationEvent(IntegrationEvent @event) => events.Add(@event);
        public void ClearAllIntefrationEvents() => events.Clear();
        public void PublishAllIntegrationEvents(IIntegrationEventsPublisher publisher)
        {
            foreach (var @event in @events)
                publisher.Publish(@event);
        }

        private readonly List<Blocking> _usersWhoBlockedTheEntity = new();
        public IReadOnlyCollection<Blocking> UsersWhoBlockedTheEntity => _usersWhoBlockedTheEntity;
        private readonly List<Blocking> _usersTheEntityBlocked = new();
        public IReadOnlyCollection<Blocking> UsersTheEntiyBlocked => _usersTheEntityBlocked;
        public void Block(string blockerId)
        {
            if (blockerId == Id)
                throw new AppException("You musn't block or unblock yourself!", HttpStatusCode.BadRequest);

            if(_usersWhoBlockedTheEntity.Any(x => x.BlockerId == blockerId))
                throw new AppException("You have already blocked the user",HttpStatusCode.BadRequest);

            _usersWhoBlockedTheEntity.Add(new Blocking(blockerId,Id));
        }
        public void RemoveBlock(string blockerId) {
            
            if (blockerId == Id)
                throw new AppException("You musn't block or unblock yourself!", HttpStatusCode.BadRequest);

            var index = _usersWhoBlockedTheEntity.FindIndex(x => x.BlockerId == blockerId);
            if (index == -1)
                throw new AppException("You didn't block the user!", HttpStatusCode.BadRequest);

            _usersWhoBlockedTheEntity.RemoveAt(index);
        }
        public bool IsBlocked(string blockerId)
        {
            return _usersWhoBlockedTheEntity.Any(x => x.BlockerId == blockerId);
        }
    }
}
