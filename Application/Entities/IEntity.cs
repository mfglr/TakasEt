namespace Application.Entities
{
	public interface IEntity
	{
        Guid Id { get; }
		DateTime CreatedDate { get; }
		DateTime? UpdatedDate { get; }

		void SetCreatedDate();
		void SetUpdatedDate();
	}
}
