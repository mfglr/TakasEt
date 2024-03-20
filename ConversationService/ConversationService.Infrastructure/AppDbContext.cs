using ConversationService.Domain.ConversationAggregate;
using ConversationService.Domain.MessageAggregate;
using ConversationService.Domain.UserConnectionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using SharedLibrary.Entities;
using System.Reflection;

namespace ConversationService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<Conversation> Conversations { get; set; }
        public DbSet<UserConnection> UserConnections { get; set; }
        public DbSet<Message> Messages { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


    }

    public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseSqlServer("Server=localhost,1433;Database=AuthDb;User=sa;Password=Pasword123*;TrustServerCertificate=True");
            return new AppDbContext(builder.Options);

        }
    }
}
