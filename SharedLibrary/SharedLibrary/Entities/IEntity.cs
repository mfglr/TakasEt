using SharedLibrary.Entities.DomainEventModels;

namespace SharedLibrary.Entities
{

    public interface IEntity : IEntity<int>
    {

    }

    public interface IEntity<TKey> : IRemovable, IDomainEventContainer, IIntegrationEventsContainer
    {
        TKey Id { get; }
        DateTime CreatedDate { get; }
        DateTime? UpdatedDate { get; }

        void SetCreatedDate();
        void SetUpdatedDate();
    }
}
