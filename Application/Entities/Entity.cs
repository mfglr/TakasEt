using Application.DomainEventModels;

namespace Application.Entities
{
    public abstract class Entity : EntityDomainEvent, IEntity
	{
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? UpdatedDate { get; protected set; }

		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}

		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
		}

	}
}
