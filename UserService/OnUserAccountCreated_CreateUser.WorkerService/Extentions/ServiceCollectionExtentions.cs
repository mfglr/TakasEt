using Microsoft.EntityFrameworkCore;
using SharedLibrary.Configurations;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using UserService.Infrastructure;

namespace OnUserAccountCreated_CreateUser.WorkerService.Extentions
{
    internal static class ServiceCollectionExtentions
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            return services
                .AddDbContext<AppDbContext>(
                   (sp, opt) =>
                   {
                       var configuration = sp.GetRequiredService<IConfiguration>();
                       opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                   },
                   ServiceLifetime.Singleton
               );
        }
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var options = configuration.GetRequiredSection("RabbitMQOptions").Get<RabbitMQOptions>()!;
            return services
                .AddSingleton<IRabbitMQOptions>(options)
                .AddSingleton<IntegrationEventPublisher>();
        }
    }
}
