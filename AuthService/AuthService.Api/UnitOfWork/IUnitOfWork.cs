namespace AuthService.Api
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
    }
}
