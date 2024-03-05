using SharedLibrary.Entities.DomainEventModels;

namespace SharedLibrary.Entities
{

    public interface IEntity : IRemovable, IDomainEventContainer, IIntegrationEventsContainer
    {
        DateTime CreatedDate { get; }
        DateTime? UpdatedDate { get; }
        void SetCreatedDate();
        void SetUpdatedDate();
    }

    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; }
    }
}
