using Application.DomainEventModels;

namespace Application.Entities
{
    public abstract class Entity : EntityDomainEvent, IEntity
	{
		public abstract int[] GetKey();
		public bool IsRemoved { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime? UpdatedDate { get; protected set; }
		public DateTime? RemovedDate {  get; protected set; }

		public void SetCreatedDate(DateTime date)
		{
			CreatedDate = date;
		}

		public void SetUpdatedDate(DateTime date)
		{
			UpdatedDate = date;
		}

		public void Remove()
		{
			IsRemoved = true;
			RemovedDate = DateTime.Now;
		}

	}
}
