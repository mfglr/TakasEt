namespace Application.Entities
{
	public interface IEntity
	{
        int Id { get; }
		DateTime CreatedDate { get; }
		DateTime? UpdatedDate { get; }

		void SetCreatedDate(DateTime date);
		void SetUpdatedDate(DateTime date);
	}
}
