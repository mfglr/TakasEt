namespace Application.Entities
{
	public interface IBaseEntity
	{
		public DateTime CreatedDate { get; }
		public DateTime? UpdatedDate { get; }
		
		int[] GetKey();
		void SetCreatedDate(DateTime date);
		void SetUpdatedDate(DateTime date);
	}
}
