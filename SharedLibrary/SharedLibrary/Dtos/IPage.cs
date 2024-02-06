namespace SharedLibrary.Dtos
{
	public interface IPage
	{
		int? Take { get; }
		int? LastId { get; }
	}
}
