namespace SharedLibrary.Dtos
{
	public interface IPage<TProperty> where TProperty : IComparable<TProperty>
	{
		int Take { get; }
        TProperty LastValue { get; }
		bool IsDescending { get; }
	}
}
