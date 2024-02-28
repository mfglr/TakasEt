using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.Services;
using System.Text;

namespace ConversationService.SignalR.Extentions
{
    public static class ServiceCollectionsExtentions
    {
        public static IServiceCollection AddJWT(this IServiceCollection services)
        {

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var tokenOptions = configuration.GetSection("TokenOptions").Get<CustomTokenOptions>()!;
            
            services
                .AddSingleton<ITokenOptions>(tokenOptions)
                .AddAuthentication(
                    options =>
                    {
                        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                    }
                )
                .AddJwtBearer(
                    JwtBearerDefaults.AuthenticationScheme,
                    opt =>
                    {
                        opt.TokenValidationParameters = new()
                        {
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
                            ValidIssuer = tokenOptions.Issuer,
                            ValidAudience = tokenOptions.Audience,

                            ValidateIssuerSigningKey = true,
                            ValidateAudience = true,
                            ValidateIssuer = true,
                        };
                    }
                );
            return services;

        }
        public static IServiceCollection AddServices(this IServiceCollection services )
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var options = configuration.GetRequiredSection("RabbitMQOptions").Get<RabbitMQOptions>()!;
            return services
                .AddSingleton<IRabbitMQOptions>(options)
                .AddSingleton<IntegrationEventPublisher>()
                .AddScoped<UserAccountService>()
                .AddScoped<BlockingCheckerService>()
                .AddHttpContextAccessor();
        }
    }
}
