using Azure.Core.Serialization;
using Application;
using Application.Configurations;
using Function.Middlewares;
using Microsoft.Azure.Functions.Worker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using Repository;
using Repository.Contexts;
using Service;
using Azure.Storage.Blobs;

var host = new HostBuilder()
	.ConfigureAppConfiguration(config =>
	{
		config.AddJsonFile("appsettings.json", false, false);
		config.Build();
	})
	.ConfigureServices(async (builder,services) =>
	{
		AddConfigurations(builder, services);
		services.AddSqlDbContext();
		services.AddApplication();
		services.AddServices();
		services.AddSingleton(new LoggedInUser());
		services.AddScoped(typeof(BlobServiceClient),serviceProvider =>
		{
			Local local = serviceProvider.GetRequiredService<Local>();
			return new BlobServiceClient(local.AzureStorage);
		});


		var customTokenOptions = services.BuildServiceProvider().GetRequiredService<CustomTokenOptions>();
		var signService = services.BuildServiceProvider().GetRequiredService<SignService>();
		services.AddSingleton(new TokenValidationParameters()
		{
			ValidIssuer = customTokenOptions.Issuer,
			ValidAudience = customTokenOptions.Audiences[0],
			IssuerSigningKey = signService.GetSymmetricSecurityKey(customTokenOptions.SecurityKey),
			ValidateIssuer = true,
			ValidateIssuerSigningKey = true,
			ValidateAudience = true,
			ValidateLifetime = true,
			ClockSkew = TimeSpan.Zero
		});

		var context = services.BuildServiceProvider().GetRequiredService<Repository.Contexts.AppDbContext>();
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



void AddConfigurations(HostBuilderContext builder, IServiceCollection services)
{
	services.AddOptions();

	services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("CustomTokenOptions"));
	CustomTokenOptions customTokenOptions = services.BuildServiceProvider().GetRequiredService<IOptions<CustomTokenOptions>>().Value;
	services.AddSingleton(customTokenOptions);

	services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));
	List<Client> clients = services.BuildServiceProvider().GetRequiredService<IOptions<List<Client>>>().Value;
	services.AddSingleton(clients);

	services.Configure<Local>(builder.Configuration.GetSection("Local"));
	Local local = services.BuildServiceProvider().GetRequiredService<IOptions<Local>>().Value;
	services.AddSingleton(local);

	services.Configure<RecursiveRepositoryOptions>(builder.Configuration.GetSection("RecursiveRepositoryOptions"));
	RecursiveRepositoryOptions recursiveRepositoryOptions = services.BuildServiceProvider().GetRequiredService<IOptions<RecursiveRepositoryOptions>>().Value;
	services.AddSingleton(recursiveRepositoryOptions);
}

