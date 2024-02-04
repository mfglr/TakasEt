using ChatMicroservice.Core.Interfaces;
using ChatMicroservice.Infrastructure.Concreats;
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

			services.AddScoped<IUnitOfWork, UnitOfWork>();
			return services.AddDbContext<ChatDbContext>(
				options => options.UseSqlServer(connectionString)
			);
		}
	}
}
