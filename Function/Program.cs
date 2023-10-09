using Azure.Core.Serialization;
using Application;
using Application.Configurations;
using Function.Middlewares;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Repository;
using Repository.Contexts;
using Service;
using Azure.Storage.Blobs;
using System.Text;

var host = new HostBuilder()
	.ConfigureAppConfiguration(config =>
	{
		config.AddJsonFile("appsettings.json", false, false);
		config.Build();
	})
	.ConfigureServices(async (builder,services) =>
	{
		services.AddOptions();
		var configuration = builder.Configuration.GetSection("Configuration").Get<Configuration>();
		services.AddSingleton(configuration);
		services.AddSqlDbContext();
		services.AddApplication();
		services.AddServices();
		services.AddSingleton(new LoggedInUser());
		services.AddScoped(typeof(BlobServiceClient),serviceProvider =>
		{
			Local local = serviceProvider.GetRequiredService<Local>();
			return new BlobServiceClient(local.AzureStorage);
		});
		
		services.AddSingleton(new TokenValidationParameters()
		{
			ValidIssuer = configuration.CustomTokenOptions.Issuer,
			ValidAudience = configuration.CustomTokenOptions.Audiences[0],
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.CustomTokenOptions.SecurityKey)),
			ValidateIssuer = true,
			ValidateIssuerSigningKey = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ClockSkew = TimeSpan.Zero
		});

		var context = services.BuildServiceProvider().GetRequiredService<AppDbContext>();
		await context.Database.MigrateAsync();
	})
	.ConfigureFunctionsWorkerDefaults(worker =>
		{
			worker.Services.Configure<WorkerOptions>(workerOptions =>
			{
				var settings = NewtonsoftJsonObjectSerializer.CreateJsonSerializerSettings();
				settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
				settings.NullValueHandling = NullValueHandling.Ignore;
				workerOptions.Serializer = new NewtonsoftJsonObjectSerializer(settings);
			});
			worker.UseMiddleware<ExceptionMiddleware>();
			worker.UseMiddleware<AuthenticationMiddleware>();
		}
)
.Build();
host.Run();
