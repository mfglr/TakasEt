using Models.DomainEventModels;
using MediatR;

namespace Models.Entities
{
    public abstract class RecursiveEntity<T> : IEntityDomainEvent, IEntity where T : RecursiveEntity<T>
    {
        public static int Depth = 2;

        public int? ParentId { get; protected set; }
        public T? Parent { get; }
        public IReadOnlyCollection<T> Children { get; }

        public int Id { get; private set; }
        public bool IsRemoved { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }
        public DateTime? RemovedDate { get; private set; }

        public int[] GetKey()
        {
            return new[] { Id };
        }

        public void Remove()
        {
            IsRemoved = true;
            RemovedDate = DateTime.Now;
        }
        public void SetCreatedDate(DateTime date)
        {
            CreatedDate = date;
        }
        public void SetUpdatedDate(DateTime date)
        {
            UpdatedDate = date;
        }

        private List<INotification> _domainEvents = new();
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
            return _domainEvents.Any();
        }
    }
}
