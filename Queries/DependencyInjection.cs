using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Queries
{
	public static class DependencyInjection
	{
		public static void AddQueries(this IServiceCollection services)
		{
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
		}
	}
}
