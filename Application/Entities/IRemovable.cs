namespace Application.Entities
{
	public interface IRemovable
	{
		bool IsRemoved { get; }
		DateTime? RemovedDate { get; }
		void Remove();
	}
}
