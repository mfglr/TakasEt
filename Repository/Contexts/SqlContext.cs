using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using Model.Entities;
using System.Linq;
using System.Linq.Expressions;

namespace Repository.Contexts
{
    public class SqlContext : IdentityDbContext<User,Role,Guid>
	{

		private IEnumerable<IEntity> GetEntitiesByState(EntityState state)
		{
			return ChangeTracker
				.Entries<IEntity>()
				.Where(x => x.State == state)
				.Select(entityEntry => entityEntry.Entity);
		}

		public SqlContext(DbContextOptions<SqlContext> options) : base(options)
		{
		}

		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			
			var createdEntity = GetEntitiesByState(EntityState.Added);
			foreach (var entity in createdEntity) entity.SetCreatedDate();

			var updatedEntity = GetEntitiesByState(EntityState.Modified);
			foreach (var entity in updatedEntity) entity.SetUpdatedDate();
			
			return base.SaveChangesAsync(cancellationToken);
		}
	}

	public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
	{
		public SqlContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
			optionsBuilder.UseSqlServer("Data Source=DESKTOP-PK4OTJR\\SQLEXPRESS01;Initial Catalog=MyBlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			return new SqlContext(optionsBuilder.Options);
		}
	}
}
