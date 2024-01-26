namespace Models.Entities
{
    //When an entity is removed, the entity is not deleted in the database permanently.
    //The entity is just pointed as deleted
    public interface IRemovable
    {
        bool IsRemoved { get; }
        DateTime? RemovedDate { get; }
        void Remove();
    }
}
