using Application.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Service
{
	public static class DependencyInjection
	{
		public static void AddServices(this IServiceCollection serviceCollection)
		{
			serviceCollection.AddScoped<ISmtpService, SmtpService>();
		}
    }
}
