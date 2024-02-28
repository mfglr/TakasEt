using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using PhotoStockMicroservice.Api.Configurations;
using PhotoStockMicroservice.Api.Services.Abstracts;
using PhotoStockMicroservice.Api.Services.Concreate;
using SharedLibrary.Configurations;
using System.Text;

namespace PhotoStockMicroservice.Api.Extentions
{
    public static class ServiceCollectionExtentions
    {
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
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var containerSettings = configuration.GetSection("ContainerSettings").Get<ContainerSettings>()!;

            return services
                .AddSingleton<IContainerSettings>(containerSettings)
                .AddScoped<IImageService, ImageService>()
                .AddScoped<IBlobService, LocalBlobService>();
        }
    }
}
