using Microsoft.IdentityModel.Tokens;
using Service;
using Repository;
using Application;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using WebApi.Extentions;
using Queries;
using Commands;
using Iss_Api.Hubs;
using Models.Configurations;
using Iss_Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOptions();
Configuration configuration = builder.Configuration.GetSection("Configuration").Get<Configuration>();
builder.Services.AddSingleton(configuration);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddSqlDbContext();
builder.Services.AddApplication();
builder.Services.AddModels();
builder.Services.AddQueries();
builder.Services.AddCommands();
builder.Services.AddServices();

builder.Services.AddAuthentication(
	options =>
	{
		options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
		options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
	}
).AddJwtBearer(
	JwtBearerDefaults.AuthenticationScheme,
	(
		options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters()
			{
				ValidIssuer = configuration.CustomTokenOptions.Issuer,
				ValidAudience = configuration.CustomTokenOptions.Audiences[0],
				IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.CustomTokenOptions.SecurityKey)),
				ValidateIssuer = true,
				ValidateIssuerSigningKey = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ClockSkew = TimeSpan.Zero
			};
		}
	)
);

builder.Services.AddCors(
	options => {
		options.AddPolicy(
			"local",
			policy => policy
				.WithOrigins("http://localhost:4200", "http://localhost:8100")
				.AllowAnyHeader()
				.AllowAnyMethod()
				.AllowCredentials()
		);
	}
);

await builder.Services.InitializeDbAsync();


var app = builder.Build();
app.UseCors("local");
app.UseRouting();
app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();
app.UseEndpoints(
	endpoints =>
	{
		endpoints.MapControllers();
		endpoints.MapHub<MessageHub>("/message");
	}
);
app.Run();


