using ChatMicroservice.Domain.ConnectionAggregate;
using ChatMicroservice.Domain.ConversationAggregate;
using ChatMicroservice.Domain.GroupAggregate;
using ChatMicroservice.Domain.MessageEntity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace ChatMicroservice.Infrastructure
{
	public class ChatDbContext : DbContext
	{
		public DbSet<Conversation> Conversations { get; set; }
		public DbSet<Group> Groups { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Connection> Connections { get; set; }
		
        public ChatDbContext(DbContextOptions<ChatDbContext> options ) : base( options ) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(modelBuilder);
		}

	}

	public class SqlContextFactory : IDesignTimeDbContextFactory<ChatDbContext>
	{
		public ChatDbContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<ChatDbContext>();
			optionsBuilder.UseSqlServer("Data Source=THENQLV;Initial Catalog=ChatDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			return new ChatDbContext(optionsBuilder.Options);
		}
	}
}
