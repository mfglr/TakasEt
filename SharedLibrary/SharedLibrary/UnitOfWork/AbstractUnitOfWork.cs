using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Services;
using System.Data;
using System.Net;

namespace SharedLibrary.UnitOfWork
{
    public abstract class AbstractUnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContext
    {

        protected IDbContextTransaction? _transaction = null;
        protected readonly TDbContext _context;
        private readonly IPublisher _publisher;
        private readonly IntegrationEventPublisher _integrationEventsPublisher;

        public AbstractUnitOfWork(TDbContext context, IPublisher publisher, IntegrationEventPublisher integrationEventsPublisher)
        {
            _context = context;
            _publisher = publisher;
            _integrationEventsPublisher = integrationEventsPublisher;
        }

        public abstract Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default);

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            //set created date
            var createdEntities = _context
                .ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);

            foreach (var item in createdEntities)
                item.SetCreatedDate();

            //set updated date
            var updatedEntities = _context
                .ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var item in updatedEntities)
                item.SetUpdatedDate();

            //save changes;
            if (_transaction == null) {
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
                await _transaction.CommitAsync(cancellationToken);
        }

        public async Task PublishDomainEventsAsync(CancellationToken cancellationToken = default)
        {
            var entities = _context
                .ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.Entity.AnyDomainEvents())
                .Select(x => x.Entity);

            foreach (var entity in entities)
            {
                await entity.PublishAllDomainEventsAsync(_publisher, cancellationToken);
                entity.ClearAllDomainEvents();
            }
        }

        public void PublishIntegrationEvents()
        {
            var entities = _context
                .ChangeTracker
                .Entries<IEntity>()
                .Where(x => x.Entity.AnyEvent())
                .Select(x => x.Entity);

            foreach (var entity in entities)
            {
                foreach (var @event in entity.Events)
                    _integrationEventsPublisher.Publish(@event);
                entity.ClearAllEvents();
            }
        }

        public async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _context.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                var message = $"Changes could not be saved:\n{ex.Message}";
                throw new AppException(message, HttpStatusCode.InternalServerError);
            }
        }
    }
}
