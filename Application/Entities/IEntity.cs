namespace Application.Entities
{
	public interface IEntity
	{
        int Id { get; }
		bool IsRemoved { get; }
		DateTime CreatedDate { get; }
		DateTime? UpdatedDate { get; }
		DateTime? RemovedDate {  get; }
		void SetCreatedDate(DateTime date);
		void SetUpdatedDate(DateTime date);
		void Remove();
	}
}
