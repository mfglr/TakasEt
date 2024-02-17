using System.Data;

namespace AuthService.Core.Abstracts
{
    public interface IUnitOfWork
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken);
        Task PublishDomainEventsAsync(CancellationToken cancellationToken);
        void PublishIntegrationEvents();
    }
}
