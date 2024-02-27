using SharedLibrary.Entities.DomainEventModels;

namespace SharedLibrary.Entities
{

    public interface IEntity
    {
        DateTime CreatedDate { get; }
        DateTime? UpdatedDate { get; }
        void SetCreatedDate();
        void SetUpdatedDate();
    }

    public interface IEntity<TKey> : IEntity, IRemovable, IDomainEventContainer, IIntegrationEventsContainer
    {
        TKey Id { get; }
    }
}
