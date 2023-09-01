using Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Application
{
	public static class DependencyInjection
	{

		public static void AddApplication(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
			serviceCollection.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			serviceCollection.AddScoped(typeof(IPipelineBehavior<,>), typeof(CustomPipeline<,>));
			serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Scoped);
		}
	}
}
