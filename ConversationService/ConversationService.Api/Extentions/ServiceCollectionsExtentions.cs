using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.Services;
using System.Text;

namespace ConversationService.Api.Extentions
{
    public static class ServiceCollectionsExtentions
    {
        public static IServiceCollection AddCustomCors(this IServiceCollection services)
        {
            return services
                .AddCors(
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
                        opt.Events = new JwtBearerEvents
                        {
                            OnMessageReceived = context =>
                            {
                                var accessToken = context.Request.Query["access_token"];
                                var path = context.HttpContext.Request.Path;
                                if (!string.IsNullOrEmpty(accessToken) && path.StartsWithSegments("/message"))
                                    context.Token = accessToken;
                                return Task.CompletedTask;
                            }
                        };

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
                .AddHttpContextAccessor()
                .AddSingleton<IRabbitMQOptions>(options)
                .AddSingleton<IntegrationEventPublisher>()
                .AddScoped<DateTimeService>()
                .AddScoped<AccountService>()
                .AddScoped<BlockingService>();
        }
    }
}
