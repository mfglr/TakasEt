using Application.DomainEventModels;
using MediatR;

namespace Application.Entities
{
    public abstract class Entity : EntityDomainEvent, IEntity
	{
        public Guid Id { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? UpdatedDate { get; private set; }

		public void SetId()
		{
			Id = Guid.NewGuid();
		}
		
		public void SetCreatedDate()
		{
			CreatedDate = DateTime.UtcNow;
		}

		public void SetUpdatedDate()
		{
			UpdatedDate = DateTime.UtcNow;
		}

	}
}
