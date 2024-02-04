using ChatMicroservice.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SharedLibrary.Entities;

namespace ChatMicroservice.Infrastructure.Concreats
{
	public class UnitOfWork : IUnitOfWork
	{

		private readonly ChatDbContext _chatDbContext;

		public UnitOfWork(ChatDbContext chatDbContext)
		{
			_chatDbContext = chatDbContext;
		}

		private IEnumerable<Entity> GetEntities(Func<EntityEntry<Entity>, bool> expression)
		{
			return _chatDbContext.ChangeTracker.Entries<Entity>().Where(expression).Select(x => x.Entity);
		}

		public async Task CommitAsync(CancellationToken cancellationToken)
		{
			var createdEntities = GetEntities(x => x.State == EntityState.Added);
            foreach (var item in createdEntities) item.SetCreatedDate();
			
			var updatedEntities = GetEntities(x => x.State == EntityState.Modified);
			foreach (var item in updatedEntities) item.SetUpdatedDate();

			await _chatDbContext.SaveChangesAsync(cancellationToken);
		}

		public bool HasChanges() => _chatDbContext.ChangeTracker.HasChanges();
	}
}
