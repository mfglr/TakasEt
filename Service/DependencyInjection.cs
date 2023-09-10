using Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Service
{
    public static class DependencyInjection
	{
		public static void AddServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<ISmtpService, SmtpService>();
			serviceCollection.AddSingleton(new SignService());
			serviceCollection.AddSingleton(new JwtSecurityTokenHandler());
			serviceCollection.AddSingleton<ITokenService, TokenService>();
			serviceCollection.AddScoped<IAuthenticationService, AuthenticationService>();
		}
    }
}
