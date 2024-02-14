namespace AuthService.Web
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(CancellationToken cancellationToken);
        Task CommitAsync(CancellationToken cancellationToken);
        Task PublishDomainEventsAsync(CancellationToken cancellationToken);
    }
}
