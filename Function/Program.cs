using Application;
using Application.Configuration;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Repository;
using Service;

var host = new HostBuilder()
	.ConfigureAppConfiguration(config =>
	{
		config.AddJsonFile("appsettings.json", false, true);
		config.Build();
	})
	.ConfigureServices((builder,services) =>
	{
		services.AddOptions();
		
		services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("TokenOptions"));
		CustomTokenOptions customTokenOptions = services.BuildServiceProvider().GetService<IOptions<CustomTokenOptions>>().Value;
		services.AddSingleton(customTokenOptions);

		services.Configure<List<Client>>(builder.Configuration.GetSection("Clients"));
		List<Client> clients = services.BuildServiceProvider().GetRequiredService<IOptions<List<Client>>>().Value;
		services.AddSingleton(clients);

		services.Configure<CustomTokenOptions>(builder.Configuration.GetSection("Local"));
		var local = services.BuildServiceProvider().GetRequiredService<IOptions<Local>>();
		services.AddSingleton(local);

		services.AddSqlDbContext();
		services.AddApplication();
		services.AddServices();

		services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,opt =>
		{
			SignService signService = services.BuildServiceProvider().GetRequiredService<SignService>();

			opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
			{


				ValidIssuer = customTokenOptions.Issuer,
				ValidAudience = customTokenOptions.Audiences[0],
				IssuerSigningKey = signService.GetSymmetricSecurityKey(customTokenOptions.SecurityKey),

				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
		});
	})
	.ConfigureFunctionsWorkerDefaults()
	.Build();

host.Run();
