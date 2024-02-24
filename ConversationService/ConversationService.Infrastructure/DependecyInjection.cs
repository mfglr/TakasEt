using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.UnitOfWork;

namespace ConversationService.Infrastructure
{
    public static class DependecyInjection
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            return services
                .AddDbContext<AppDbContext>(
                   (sp, opt) =>
                   {
                       var configuration = sp.GetRequiredService<IConfiguration>();
                       opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                   }
                )
                .AddScoped<IUnitOfWork,UnitOfWork>();
        }
    }
}
