using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.PipelineBehaviors;
using System.Reflection;

namespace AuthService.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApp(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return services
               .AddValidatorsFromAssembly(assembly)
               .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly))
               .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
               .AddTransient(typeof(IPipelineBehavior<,>), typeof(EventsPublishPipelineBehavior<,>));
        }
    }
}
