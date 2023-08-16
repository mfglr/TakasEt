using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
	public static class DependencyInjection
	{

		public static void AddApplication(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
			serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Scoped);
		}
	}
}
