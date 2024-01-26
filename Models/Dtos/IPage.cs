namespace Models.Dtos
{
	public interface IPage
	{
		int? Take { get; }
		int? LastId { get; }
	}
}
