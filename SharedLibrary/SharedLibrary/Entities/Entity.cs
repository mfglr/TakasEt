namespace SharedLibrary.Entities
{
	public abstract class Entity : IRemovable
	{
		public int Id { get; protected set; }
		public DateTime CreatedDate { get; protected set; }
		public DateTime? UpdatedDate { get; protected set; }

		public void SetCreatedDate() => CreatedDate = DateTime.Now;
		public void SetUpdatedDate() => UpdatedDate = DateTime.Now;

		//IRemovable
		public bool IsRemoved { get; protected set; }
		public DateTime? RemovedDate { get; protected set; }
		public virtual void Remove()
		{
			IsRemoved = true;
			RemovedDate = DateTime.Now;
		}
		public virtual void Reinsert()
		{
			IsRemoved = false;
			RemovedDate = null;
		}
	}
}
