using Models.Interfaces;
using Models.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Models.Configurations;
using Models.Entities;
using Repository.Contexts;
using Repository.Repositories;
using Repository.UnitOfWorks;

namespace Repository
{
    public static class DependencyInjection
	{
		public static void AddSqlDbContext(this IServiceCollection serviceCollection)
		{
			Configuration configuration = serviceCollection.BuildServiceProvider().GetRequiredService<Configuration>();
			serviceCollection.AddDbContext<AppDbContext>(optionsAction =>
			{
				optionsAction.UseSqlServer(configuration.Local.SqlConnectionString);
			});

			serviceCollection.AddIdentityCore<User>(opt =>
			{
				opt.User.RequireUniqueEmail = true;
				opt.Password.RequireNonAlphanumeric = false;
			}).AddEntityFrameworkStores<AppDbContext>();

			serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
		}

	}
}
