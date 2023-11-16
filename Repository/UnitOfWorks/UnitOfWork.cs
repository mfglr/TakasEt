using Application.DomainEventModels;
using Application.Entities;
using Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Repository.Contexts;

namespace Repository.UnitOfWorks
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		private readonly IPublisher _publisher;

		public UnitOfWork(AppDbContext context, IPublisher publisher)
		{
			_context = context;
			_publisher = publisher;
		}

		public async Task<DateTime> CommitAsync(CancellationToken cancellationToken)
		{
			var entitiesThatHaveDomainEvents = GetEntities<IEntityDomainEvent>(x => x.Entity.AnyDomainEvents());
			foreach (var entity in entitiesThatHaveDomainEvents)
			{
				entity.PublishAllDomainEvents(_publisher);
				entity.ClearAllDomainEvents();
			}
			var date = DateTime.Now;
			var createdEntity = GetEntities<IEntity>(x => x.State == EntityState.Added);
			foreach (var entity in createdEntity)entity.SetCreatedDate(date);
			var updatedEntity = GetEntities<IEntity>(x => x.State == EntityState.Modified);
			foreach (var entity in updatedEntity) entity.SetUpdatedDate(date);
			await _context.SaveChangesAsync(cancellationToken);
			return date;
		}


		public bool HasChanges()
		{
			return _context.ChangeTracker.HasChanges();
		}

		public IEnumerable<T> GetEntities<T>(Func<EntityEntry<T>, bool> expression) where T : class
		{
			return _context.ChangeTracker.Entries<T>().Where(expression).Select(x => x.Entity);
		}
	}
}
