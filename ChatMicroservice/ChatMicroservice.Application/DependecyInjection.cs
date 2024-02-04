using ChatMicroservice.Application.PipelineBehaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ChatMicroservice.Application
{
	public static class DependecyInjection
	{
		public static IServiceCollection AddApplication(this IServiceCollection services)
		{
			var assembly = Assembly.GetExecutingAssembly();
			services.AddAutoMapper(assembly);
			services.AddValidatorsFromAssembly(assembly, ServiceLifetime.Scoped);
			services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly));
			services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppPipelineBehavior<,>));
			return services;
		}
	}
}
