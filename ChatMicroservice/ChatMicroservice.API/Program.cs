using ChatMicroservice.API.Hubs;
using ChatMicroservice.Infrastructure;
using ChatMicroservice.Application;
using RabbitMQ.Client;
using SharedLibrary.Services;
using SharedLibrary.ValueObjects;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSignalR();
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
builder.Services.AddSqlDbContext();
builder.Services.AddApplication();
builder.Services.AddSingleton(
	sp =>
	{
		var configuration = sp.GetRequiredService<IConfiguration>();
		var hostName = configuration.GetConnectionString("RabbitMQHostName");
		return new ConnectionFactory() { HostName = hostName };
	}
);
builder.Services.AddSingleton<NotificationPublisher>();


var app = builder.Build();


	// Configure the HTTP request pipeline.

	app.UseHttpsRedirection();
app.UseCors("local");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat-hub");
app.Run();
