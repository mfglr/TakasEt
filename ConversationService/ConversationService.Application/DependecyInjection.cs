using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SharedLibrary.PipelineBehaviors;
using System.Reflection;

namespace ConversationService.Application
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            return services
                .AddAutoMapper(assembly)
                .AddValidatorsFromAssembly(assembly)
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(EventsPublishPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(DateTimePipelineBehavior<,>));
            ;
        }

    }
}
