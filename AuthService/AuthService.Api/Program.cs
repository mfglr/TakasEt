using SharedLibrary;
using AuthService.Infrastructure;
using AuthService.Api.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAppSharedLibrary();
builder.Services.AddCustomDbContext();
builder.Services.AddCustomIdentity();
builder.Services.AddJWTConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
