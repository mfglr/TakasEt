using AuthService.Web.Entities;
using AuthService.Web.PipelineBehaviors;
using AuthService.Web.Services;
using AuthService.Web.TokenProviders;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Text;

namespace AuthService.Web.Extentions
{
    internal static class ServiceCollectionsExtetions
    {

        public static IServiceCollection AddCustomDbContext(this IServiceCollection services)
        {
            return services
                .AddDbContext<AppDbContext>(
                    (sp, builder) => {
                        var configuration = sp.GetRequiredService<IConfiguration>();
                        builder.UseSqlServer(configuration.GetConnectionString("SqlServer"));
                    }
                )
                .AddScoped<IUnitOfWork,UnitOfWork>();
        }

        public static IServiceCollection AddCustomIdentity(this IServiceCollection services)
        {
            //customize identity
            services
                .AddIdentity<User, IdentityRole>(
                    opt =>
                    {
                        opt.User.RequireUniqueEmail = true;
                        opt.Password.RequiredLength = 9;
                        opt.Password.RequireLowercase = true;
                        opt.Password.RequireUppercase = true;
                        opt.Password.RequireNonAlphanumeric = true;
                        opt.Password.RequireDigit = false;

                        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
                        opt.Lockout.MaxFailedAccessAttempts = 5;
                    }
                )
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders()
                .AddTokenProvider<RefreshTokenProvider<User>>(TokenProvider.RefreshTokenProvider.Name);

            //configure Refresh token provider;
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.Configure<TokenConfiguration>(configuration.GetSection("TokenConfiguration"));
            var tokenConfiguration = services.BuildServiceProvider().GetRequiredService<IOptions<TokenConfiguration>>().Value;
            services.Configure<RefreshTokenProviderOptions>(opt =>
            {
                opt.TokenLifespan = TimeSpan.FromMinutes(tokenConfiguration.RefreshTokenExpiration);
            });


            return services;
        }

        public static IServiceCollection AddJWT(this IServiceCollection services)
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
                )
                .AddScoped<ITokenService, TokenService>()
                .AddScoped<IAuthenticationService, AuthenticationService>();
        }

        public static IServiceCollection AddCustomMediatR(this IServiceCollection services)
        {
            return services
                .AddMediatR(
                    cnfg => cnfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly())
                )
                .AddTransient(typeof(IPipelineBehavior<,>),typeof(AppPipelineBehavior<,>));
        }

    }
}
