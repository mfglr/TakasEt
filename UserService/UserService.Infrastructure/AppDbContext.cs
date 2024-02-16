using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SharedLibrary.Entities;
using System.Reflection;
using UserService.Domain.UserAggregate;

namespace UserService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //set created date
            var createdEntities = ChangeTracker
                .Entries<IEntity<Guid>>()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity);

            foreach (var item in createdEntities)
                item.SetCreatedDate();

            //set updated date
            var updatedEntities = ChangeTracker
                .Entries<IEntity<Guid>>()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity);

            foreach (var item in updatedEntities)
                item.SetUpdatedDate();

            return base.SaveChangesAsync(cancellationToken);
        }

    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Data Source=THENQLV;Initial Catalog=UserDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new AppDbContext(builder.Options);

        }
    }


}
