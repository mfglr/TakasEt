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
            return services
                .AddAutoMapper(assembly)
				.AddValidatorsFromAssembly(assembly, ServiceLifetime.Scoped)
				.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly))
				.AddTransient(typeof(IPipelineBehavior<,>), typeof(AppPipelineBehavior<,>));
		}
	}
}
