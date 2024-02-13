using AuthService.Domain.UserAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AuthService.Infrastructure
{
    public class DbContext : IdentityDbContext<User,IdentityRole,string>
    {
        public DbContext(DbContextOptions<DbContext> options) : base(options) { }
    }

    public class DbContextFactory : IDesignTimeDbContextFactory<DbContext>
    {
        public DbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<DbContext>();
            builder.UseSqlServer("Data Source=THENQLV;Initial Catalog=AuthDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            return new DbContext(builder.Options);

        }
    }


}
