using Application.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Repository.Contexts;

namespace WebApi.Extentions
{
	public static class DbInitializer
	{
		public static async Task InitializeDbAsync(this IServiceCollection serviceCollection)
		{
			var context = serviceCollection.BuildServiceProvider().GetRequiredService<AppDbContext>();
			await context.Database.MigrateAsync();


			//var set = context.Set<User>();
			//FileStream file = File.OpenRead(Directory.GetCurrentDirectory() + "/JsonFiles/usersJsonFile.json");
			//using (var reader = new StreamReader(file))
			//{
			//	string json;
			//	User user;
			//	while ((json = reader.ReadLine()) != null)
			//	{
			//		user = JsonConvert.DeserializeObject<User>(json);
			//		await set.AddAsync(user);
			//	}
			//	await context.SaveChangesAsync();
			//}

		}
	}
}
