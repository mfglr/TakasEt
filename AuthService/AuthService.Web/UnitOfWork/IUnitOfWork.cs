using System.Data;

namespace AuthService.Web
{
    internal interface IUnitOfWork
    {
        Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted,CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken);
        Task PublishDomainEventsAsync(CancellationToken cancellationToken);
        void PublishAllIntegrationEvents();
    }
}
