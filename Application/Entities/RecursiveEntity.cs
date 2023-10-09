using Application.DomainEventModels;

namespace Application.Entities
{
	public abstract class RecursiveEntity<T> : EntityDomainEvent, IEntity where T : RecursiveEntity<T>
	{
		public static int Depth = 2; 
		public Guid? ParentId { get; protected set; }
		public T? Parent { get; }
		public IReadOnlyCollection<T> Children { get; }

		public Guid Id { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public DateTime? UpdatedDate { get; private set; }


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
