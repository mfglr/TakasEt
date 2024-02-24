using ConversationService.SignalR.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ConversationService.SignalR.Extentions
{
    public static class ServiceCollectionsExtentions
    {

        public static IServiceCollection AddJWT(this IServiceCollection services)
        {

            var configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>()!;
            
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

    }
}
