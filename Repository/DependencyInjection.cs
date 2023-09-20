using Application.Configurations;
using Application.Entities;
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
			serviceCollection.AddDbContext<Contexts.AppDbContext>(optionsAction =>
			{
				optionsAction.UseSqlServer(local.SqlConnectionString);
			});
			serviceCollection.AddIdentityCore<User>(opt =>
			{
				opt.User.RequireUniqueEmail = true;
				opt.Password.RequireNonAlphanumeric = false;
			}).AddEntityFrameworkStores<Contexts.AppDbContext>();
			serviceCollection.AddScoped(typeof(IRepository<>), typeof(Repository<>));
			serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
		}

	}
}
