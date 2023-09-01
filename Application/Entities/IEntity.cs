namespace Application.Entities
{
	public interface IEntity
	{
        Guid Id { get; }
		DateTime CreatedDate { get; }
		DateTime? UpdatedDate { get; }

        void SetId();
		void SetCreatedDate();
		void SetUpdatedDate();
	}
}
