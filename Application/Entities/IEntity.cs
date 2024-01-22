namespace Application.Entities
{
	public interface IEntity : IBaseEntity, IRemovable
	{
        int Id { get; }
    }
}
