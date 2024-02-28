using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SharedLibrary.Configurations;
using SharedLibrary.PipelineBehaviors;
using SharedLibrary.Services;
using SharedLibrary.UnitOfWork;
using System.Reflection;
using System.Text;
using UserService.Api.Filters;
using UserService.Application.Dtos;
using UserService.Application.Validators;
using UserService.Infrastructure;

namespace UserService.Api.Extentions
{
    public static class ServiceCollecionExtentions
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
               ).AddScoped<IUnitOfWork, UnitOfWork>();
        }
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
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var options = configuration.GetRequiredSection("RabbitMQOptions").Get<RabbitMQOptions>()!;

            return services
                .AddSingleton<IRabbitMQOptions>(options)
                .AddSingleton<IntegrationEventPublisher>()
                .AddHttpContextAccessor()
                .AddScoped<UserNotFoundFilter>()
                .AddScoped<UserAccountService>()
                .AddScoped<BlockingCheckerService>();
        }
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            return services
                .AddMediatR(x => x.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(UnfollowDto))!))
                .AddValidatorsFromAssembly(Assembly.GetAssembly(typeof(FollowCommandValidator)))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(EventsPublishPipelineBehavior<,>));
        }
    }
}
