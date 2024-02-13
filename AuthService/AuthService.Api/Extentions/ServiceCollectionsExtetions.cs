using AuthService.Domain.UserAggregate;
using AuthService.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace AuthService.Api.Extentions
{
    public static class ServiceCollectionsExtetions
    {

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            services
                .AddIdentity<User,IdentityRole>(
                    opt =>
                    {
                        opt.User.RequireUniqueEmail = true;
                        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyz1234567890_";
                        opt.Password.RequiredLength = 9;
                        opt.Password.RequireLowercase = true;
                        opt.Password.RequireUppercase = true;
                        opt.Password.RequireNonAlphanumeric = true;
                        opt.Password.RequireDigit = false;

                        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                        opt.Lockout.MaxFailedAccessAttempts = 5;
                    }
                )
                .AddEntityFrameworkStores<DbContext>();

            return services;
        }

        public static IServiceCollection AddJWTConfiguration(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<TokenConfiguration>(configuration.GetSection("TokenConfiguration"));

            return services
                .AddSingleton<ITokenConfiguration>(
                    sp => sp.GetRequiredService<IOptions<TokenConfiguration>>().Value
                )
                .AddSingleton<JwtSecurityTokenHandler>()
                .AddSingleton(
                    sp =>
                    {
                        var _tokenConfiguration = sp.GetRequiredService<ITokenConfiguration>();
                        return new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenConfiguration.SecurityKey)),
                            SecurityAlgorithms.HmacSha256Signature
                        );
                    }
                );
        }

    }
}
