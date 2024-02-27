namespace SharedLibrary.Dtos
{
	public interface IPage
	{
		int? Take { get; }
		DateTime? LastDate { get; }
	}
}
