using Application.DomainEventModels;
using Application.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Repository.Contexts
{
    public class SqlContext : IdentityDbContext<User,Role,Guid>
	{

        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        private readonly IPublisher publisher;

		private IEnumerable<IEntity> GetEntitiesByState(EntityState state)
		{
			return ChangeTracker
				.Entries<IEntity>()
				.Where(x => x.State == state)
				.Select(entityEntry => entityEntry.Entity);
		}

		private IEnumerable<IEntityDomainEvent> GetEntitiesThatHaveDomainEvents()
		{
			var data = ChangeTracker
				.Entries<IEntityDomainEvent>()
				.Where(x => x.Entity.AnyDomainEvents())
				.Select(entityEntry => entityEntry.Entity);
			return data;
		}

		public SqlContext(DbContextOptions<SqlContext> options) : base(options)
		{
		}

		public SqlContext(DbContextOptions<SqlContext> options, IPublisher publisher) : base(options)
		{
			this.publisher = publisher;
		}
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(builder);
		}
		public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
		{
			
			var createdEntity = GetEntitiesByState(EntityState.Added);
			foreach (var entity in createdEntity) entity.SetCreatedDate();

			var updatedEntity = GetEntitiesByState(EntityState.Modified);
			foreach (var entity in updatedEntity) entity.SetUpdatedDate();

			var entitiesThatHaveDomainEvents = GetEntitiesThatHaveDomainEvents();
			foreach (var entity in entitiesThatHaveDomainEvents)
			{
				entity.PublishAllDomainEvents(publisher);
				entity.ClearAllDomainEvents();
			}
			return base.SaveChangesAsync(cancellationToken);
		}
	}

	public class SqlContextFactory : IDesignTimeDbContextFactory<SqlContext>
	{
		public SqlContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<SqlContext>();
			optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyBlogDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			return new SqlContext(optionsBuilder.Options);
		}
	}
}
