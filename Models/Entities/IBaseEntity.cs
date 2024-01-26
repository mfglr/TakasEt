namespace Models.Entities
{
    public interface IBaseEntity
    {
		int[] GetKey();
		DateTime CreatedDate { get; }
        DateTime? UpdatedDate { get; }
        void SetCreatedDate(DateTime date);
        void SetUpdatedDate(DateTime date);
    }
}
