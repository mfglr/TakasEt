using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Handler
{
	public static class DependencyInjection
	{
		public static void AddHandlers(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		}
	}
}
