namespace ChatMicroservice.Core.Interfaces
{
	public interface IUnitOfWork
	{
		Task CommitAsync(CancellationToken cancellationToken);
		bool HasChanges();
	}
}
