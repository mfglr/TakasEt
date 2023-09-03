using Application.DomainEventModels;

namespace Application.Entities
{
	public abstract class RecursiveEntity<T> : EntityDomainEvent, IEntity where T : RecursiveEntity<T>
	{
		private readonly List<T> _children = new List<T>();

		public Guid? ParentId { get; protected set; }
		public T? Parent { get; }
		public IReadOnlyCollection<T> Children { get; }

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

		public void AddChild(T child)
		{
			_children.Add(child);
		}
		public void RemoveChild(T child)
		{
			_children.Remove(child);
		}

		
	}
}
