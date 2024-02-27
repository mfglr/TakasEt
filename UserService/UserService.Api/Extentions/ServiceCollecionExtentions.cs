using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserService.Api.Configurations;

namespace UserService.Api.Extentions
{
    public static class ServiceCollecionExtentions
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var tokenOptions = configuration.GetSection("TokenOptions").Get<CustomTokenOptions>()!;

            services
                .AddSingleton<ITokenOptions>(tokenOptions)
                .AddAuthentication(opt =>
                {
                    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, opt =>
                {
                    opt.TokenValidationParameters = new()
                    {
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                        ValidIssuer = tokenOptions.Issuer,
                        ValidAudience = tokenOptions.Audience,

                        ValidateIssuerSigningKey = true,
                        ValidateAudience = true,
                        ValidateIssuer = true,
                        ValidateLifetime = true,
                    };
                });
            return services;
        }
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            return services.AddCors(
                options => {
                    options.AddPolicy(
                        "local",
                        policy => policy
                            .WithOrigins("http://localhost:4200", "https://localhost:8100")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials()
                    );
                }
            );
        }
    }
}
