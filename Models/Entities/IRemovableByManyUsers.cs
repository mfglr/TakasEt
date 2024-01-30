namespace Models.Entities
{
	public interface IRemovableByManyUsers<TCrossEntity> where TCrossEntity : CrossEntity
	{
		IReadOnlyCollection<TCrossEntity> UsersWhoRemoved { get; }
		void RemoveFromUser(int removerId);
	}
}
