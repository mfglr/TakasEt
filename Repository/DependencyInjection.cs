using Application.Configurations;
using Application.Interfaces;
using Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Contexts;
using Repository.Repositories;
using Repository.UnitOfWorks;

namespace Repository
{
    public static class DependencyInjection
	{
		public static void AddSqlDbContext(this IServiceCollection serviceCollection)
		{
			Local local = serviceCollection.BuildServiceProvider().GetRequiredService<Local>();
			serviceCollection.AddDbContext<SqlContext>(optionsAction =>
			{
				optionsAction.UseSqlServer(local.SqlConnectionString);
			});
			serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
		}

	}
}
