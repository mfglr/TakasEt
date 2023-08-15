using Application.Entities;
using Application.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Repository.Contexts;
using Repository.UnitOfWorks;

namespace Repository
{
    public static class DependencyInjection
	{
		public static void AddSqlDbContext(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddDbContext<SqlContext>(optionsAction =>
			{
				optionsAction.UseSqlServer("Data Source=DESKTOP-8JFIPPP\\SQLSERVICE;Initial Catalog=MyBlog;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
			});
			serviceCollection.AddIdentityCore<User>().AddEntityFrameworkStores<SqlContext>();
			serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
		}

	}
}
