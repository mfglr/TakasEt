using Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;
using System.IdentityModel.Tokens.Jwt;

namespace Service
{
    public static class DependencyInjection
	{
		public static void AddServices(this IServiceCollection services)
		{
			services.AddScoped<ISmtpService, SmtpService>();
			services.AddSingleton(new SignService());
			services.AddSingleton(new JwtSecurityTokenHandler());
			services.AddSingleton<ITokenService, TokenService>();
			services.AddScoped<IAuthenticationService, AuthenticationService>();
			services.AddScoped<IBlobService,BlobService>();
			services.AddSingleton<IRoleService, RoleService>();
			services.AddTransient<IFileWriterService, FileWriterService>();
		}
    }
}
