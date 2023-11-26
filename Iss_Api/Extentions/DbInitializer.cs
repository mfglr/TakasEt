using Microsoft.EntityFrameworkCore;
using Repository.Contexts;

namespace WebApi.Extentions
{
	public static class DbInitializer
	{
		public static async Task InitializeDbAsync(this IServiceCollection serviceCollection)
		{
			var context = serviceCollection.BuildServiceProvider().GetRequiredService<AppDbContext>();
			await context.Database.MigrateAsync();
		}
	}
}
