using AuthService.Core.Interfaces;
using AuthService.Domain.UserAggregate;
using AuthService.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace AuthService.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {
            return services
                .AddDbContext<DbContext>(
                    (sp, builder) => {
                        var configuration = sp.GetRequiredService<IConfiguration>();
                        builder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                    }
                );
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services
                .AddSingleton<ISignService,SignService>();
        }

    }
}
