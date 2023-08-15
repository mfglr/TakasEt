using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
	public static class DependencyInjection
	{

		public static void AddApplication(this IServiceCollection collection)
		{
			collection.AddAutoMapper(Assembly.GetExecutingAssembly());
			collection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		}
	}
}
