using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Reflection;

namespace Repository.Contexts
{
    public class SqlContext : DbContext
	{
        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Credit> Credits { get; set; }
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }
        public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; } 

		public SqlContext(DbContextOptions<SqlContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			base.OnModelCreating(builder);
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
