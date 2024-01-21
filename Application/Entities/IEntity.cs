namespace Application.Entities
{
	public interface IEntity
	{
		int[] GetKey();
		bool IsRemoved { get; }
		DateTime CreatedDate { get; }
		DateTime? UpdatedDate { get; }
		DateTime? RemovedDate {  get; }
		void SetCreatedDate(DateTime date);
		void SetUpdatedDate(DateTime date);
		void Remove();
	}
}
