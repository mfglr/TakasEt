using AuthService.Core.Abstracts;
using AuthService.Core.Entities;
using AuthService.Core.ValueObjects;
using AuthService.Infrastructure;
using AuthService.Infrastructure.Services;
using AuthService.Web.TokenProviders;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
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
                .AddIdentity<UserAccount, IdentityRole>(
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
                .AddTokenProvider<RefreshTokenProvider<UserAccount>>(TokenProvider.RefreshTokenProvider.Name);

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

        public static IServiceCollection AddThirdPartyAuhentication(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddAuthentication().AddFacebook(facebookOptions =>
            {
                facebookOptions.AppId = configuration["Authentication:Facebook:AppId"]!;
                facebookOptions.AppSecret = configuration["Authentication:Facebook:AppSecret"]!;
            });

            return services;
        }

        public static IServiceCollection AddJWT(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var tokenConfiguration = configuration.GetSection("TokenConfiguration").Get<TokenConfiguration>()!;
      
            services
                .AddSingleton<ITokenConfiguration>(tokenConfiguration)
                .AddSingleton<JwtSecurityTokenHandler>()
                .AddSingleton(
                    sp =>
                    {
                        return new SigningCredentials(
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.SecurityKey)),
                            SecurityAlgorithms.HmacSha256Signature
                        );
                    }
                )
                .AddScoped<ITokenService, TokenService>();

            services
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenConfiguration.SecurityKey)),
                        ValidIssuer = tokenConfiguration.Issuer,
                        ValidAudience = tokenConfiguration.Audiences[0],

                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                    };
                });

            return services;
        }

    }
}
