using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Command
{
	public static class DependencyInjection
	{
		public static void AddCommand(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		}
	}
}
