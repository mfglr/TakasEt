namespace SharedLibrary.Entities
{

    public interface IEntity : IEntity<int>
    {

    }

    public interface IEntity<TKey> : IRemovable
    {
        TKey Id { get; }
        DateTime CreatedDate { get; }
        DateTime? UpdatedDate { get; }

        void SetCreatedDate();
        void SetUpdatedDate();
    }
}
