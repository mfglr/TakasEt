using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Contexts;

namespace Repository
{
    public static class DependencyInjection
	{
		public static void AddSqlDbContext(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<SqlContext>(optionsAction =>
			{
				optionsAction.UseSqlServer(Environment.GetEnvironmentVariable("SqlConnectionString"));
			});
			serviceCollection.AddIdentityCore<User>().AddEntityFrameworkStores<SqlContext>();
		}

	}
}
