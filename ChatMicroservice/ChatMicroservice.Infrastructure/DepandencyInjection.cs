using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatMicroservice.Infrastructure
{
	public static class DepandencyInjection
	{
		public static IServiceCollection AddSqlDbContext(this IServiceCollection services)
		{

			var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
			var connectionString = configuration.GetConnectionString("sqlConnectionString");

			services.AddDbContext<ChatDbContext>(
				options =>{
					options.UseSqlServer(connectionString);
				}
			);

			return services;
		}
	}
}
