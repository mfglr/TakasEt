namespace Models.Entities
{
	public interface IExplorable<TCrossEntity> where TCrossEntity : CrossEntity
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoExplored { get; }
		void Explore(int userId);
		bool IsExplored(int userId);
	}
}
