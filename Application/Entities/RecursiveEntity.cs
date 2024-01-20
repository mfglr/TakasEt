using Application.DomainEventModels;

namespace Application.Entities
{
	public abstract class RecursiveEntity<T> : EntityDomainEvent, IEntity where T : RecursiveEntity<T>
	{
		public static int Depth = 2;
        public int? ParentId { get; protected set; }
		public T? Parent { get; }
		public IReadOnlyCollection<T> Children { get; }

		public int Id { get; private set; }
		public DateTime CreatedDate { get; private set; }
		public DateTime? UpdatedDate { get; private set; }

		public bool IsRemoved => throw new NotImplementedException();

		public DateTime? RemovedDate => throw new NotImplementedException();

		public void Remove()
		{
			throw new NotImplementedException();
		}

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
