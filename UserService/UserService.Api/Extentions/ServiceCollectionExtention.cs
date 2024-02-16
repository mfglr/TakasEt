using Microsoft.EntityFrameworkCore;
using UserService.Infrastructure;

namespace UserService.Api.Extentions
{
    public static class ServiceCollectionExtention
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services)
        {
            return services.AddDbContext<AppDbContext>(
                (sp, opt) =>
                {
                    var configuration = sp.GetRequiredService<IConfiguration>();
                    opt.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                }
            );
        }
    }
}
