using AuthService.Application;
using AuthService.Web.Extentions;
using AuthService.Web.Filters;
using SharedLibrary;
using SharedLibrary.Middlewares;
using SharedLibrary.Services;
using System.Text.Json.Serialization;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllersWithViews()
    .AddJsonOptions(
        options =>
        {
            options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        }
    );

builder.Services.AddScoped<AccountNotFoundFilter>();

builder.Services.AddScoped<UserAccountService>();
builder.Services.AddScoped<BlockingCheckerService>();

builder.Services.AddCustomDbContext();
builder.Services.AddCustomIdentity();
builder.Services.AddJWT();
builder.Services.AddApp();
builder.Services.AddJsonSerializerSettingsForCustomExceptionMiddleware();
builder.Services.AddIntegrationEventsPublisher();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
