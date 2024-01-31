using Application.Pipelines;
using Commands;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Queries;
using System.Reflection;

namespace Application
{
	public static class DependencyInjection
	{
		public static void AddApplication(this IServiceCollection services)
		{
			services.AddModels();
			services.AddCommands();
			services.AddQueries();
			services.AddAutoMapper(Assembly.GetExecutingAssembly());
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
			services.AddScoped(typeof(IPipelineBehavior<,>), typeof(AppPipelineBehavior<,>));
			services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly(),ServiceLifetime.Scoped);
		}
	}
}
