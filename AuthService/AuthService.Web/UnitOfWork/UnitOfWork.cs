using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SharedLibrary.Entities;
using SharedLibrary.Exceptions;
using System.Data;
using System.Net;

namespace AuthService.Web
{
    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly IPublisher _publisher;

        private IDbContextTransaction? _transaction = null;

        public UnitOfWork(AppDbContext context, IPublisher publisher)
        {
            _context = context;
            _publisher = publisher;
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
                throw new AppException("A transaction could not be initialized!", HttpStatusCode.InternalServerError);
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
    }
}
