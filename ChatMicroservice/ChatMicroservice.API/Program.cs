using ChatMicroservice.Application;
using ChatMicroservice.Application.Hubs;
using ChatMicroservice.Infrastructure;
using SharedLibrary;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
	.AddControllers()
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        }
    );
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

builder.Services.AddAppSharedLibrary();
builder.Services.AddSqlDbContext();
builder.Services.AddApplication();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseCors("local");
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat-hub");
app.Run();
