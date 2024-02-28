using MediatR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Exceptions;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using System.Data;
using System.Net;

namespace UserService.Infrastructure
{
    public class UnitOfWork : AbstractUnitOfWork<AppDbContext, Guid>
    {
        public UnitOfWork(AppDbContext context, IPublisher publisher, IntegrationEventPublisher integrationEventsPublisher) : base(context, publisher, integrationEventsPublisher)
        {
        }

        public override async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            try
            {
                _transaction = await _context.Database.BeginTransactionAsync(isolationLevel, cancellationToken);
            }
            catch (Exception)
            {
                throw new AppException("A transaction could not be initialized!", HttpStatusCode.InternalServerError);
            }
        }
    }
}
