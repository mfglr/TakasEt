namespace ChatMicroservice.Core.Interfaces
{
	public interface IUnitOfWork
	{
		Task<int> CommitAsync(CancellationToken cancellationToken);
		bool HasChanges();
	}
}
