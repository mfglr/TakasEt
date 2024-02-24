using System.Data;

namespace SharedLibrary.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task PublishDomainEventsAsync(CancellationToken cancellationToken = default);
        void PublishIntegrationEvents();
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
