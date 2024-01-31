namespace Models.Entities
{
	public interface IExplorable<TCrossEntity,T,V>
		where T : IBaseEntity
		where V : User
		where TCrossEntity : CrossEntity<T,V>
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoExplored { get; }
		void Explore(int userId);
		bool IsExplored(int userId);
	}
}
