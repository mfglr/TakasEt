using AuthService.Core.Abstracts;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using SharedLibrary.Services;
using System.Data;
using System.Net;

namespace AuthService.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;
        private readonly IIntegrationEventsPublisher _integrationEventsPublisher;

        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(AppDbContext context, IPublisher publisher, IIntegrationEventsPublisher integrationEventsPublisher)
        {
            _context = context;
            _publisher = publisher;
            _integrationEventsPublisher = integrationEventsPublisher;
        }

        public async Task BeginTransactionAsync(IsolationLevel isolationLevel = IsolationLevel.ReadCommitted, CancellationToken cancellationToken = default)
        {
            try
            {
                _transaction = await _context.Database.BeginTransactionAsync(isolationLevel,cancellationToken);
            }
            catch (Exception ex)
            {
                throw new AppException("A transaction could not be initialized!", HttpStatusCode.InternalServerError);
            }
        }
     

        public async Task CommitAsync(CancellationToken cancellationToken)
        {
            
            //set created date
            var createdEntities = _context
                .ChangeTracker
                .Entries<IEntity<string>>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);
                
            foreach (var item in createdEntities)
                item.SetCreatedDate();

            //set updated date
            var updatedEntities = _context
                .ChangeTracker
                .Entries<IEntity<string>>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var item in updatedEntities)
                item.SetUpdatedDate();

            //commit changes;
            if (_transaction == null)
                await _context.SaveChangesAsync(cancellationToken);
            else
                await _transaction.CommitAsync(cancellationToken);
        }

        public async Task PublishDomainEventsAsync(CancellationToken cancellationToken)
        {
            //publish domain events;
            var entities = _context
                .ChangeTracker
                .Entries<IEntity<string>>()
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
            //publish integration events;
            var entities = _context
                .ChangeTracker
                .Entries<IEntity<string>>()
                .Where(x => x.Entity.AnyIntegrationEvent())
                .Select(x => x.Entity);

            foreach (var entity in entities) { 
                entity.PublishAllIntegrationEvents(_integrationEventsPublisher);
                entity.ClearAllIntefrationEvents();
            }
        }


    }
}
