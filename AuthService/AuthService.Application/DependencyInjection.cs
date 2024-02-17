using AuthService.Application.PipelineBehaviors;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
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
               .AddMediatR(
                   cnfg => cnfg.RegisterServicesFromAssemblies(assembly)
               )
               .AddTransient(typeof(IPipelineBehavior<,>), typeof(AppPipelineBehavior<,>));
        }
    }
}
