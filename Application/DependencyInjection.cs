using Application.Configurations;
using Application.Pipelines;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace Application
{
	public static class DependencyInjection
	{

		public static void AddApplication(this IServiceCollection services)
		{
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(CustomPipeline<,>));
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Scoped);
		}

		
	}
}
