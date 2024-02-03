namespace SharedLibrary.Entities
{
	/*
	 * !!!The application can restore user data when users delete their accounts and want to recover them.!!!
	 * 
	 * When an entity is removed, the entity is not permanently deleted. It is just pointed as deleted.
	 * 
	 */

	public interface IRemovable
	{
		bool IsRemoved { get; }
		DateTime? RemovedDate { get; }
		void Remove();
		void Reinsert();
	}
}
