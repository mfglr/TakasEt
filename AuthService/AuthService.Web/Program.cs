using AuthService.Web.Extentions;
using SharedLibrary;
using SharedLibrary.Middlewares;
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

builder.Services.AddCustomDbContext();
builder.Services.AddJWT();
builder.Services.AddCustomIdentity();

builder.Services.AddCustomMediatR();
builder.Services.AddJsonSerializerSettingsForCustomExceptionMiddleware();
builder.Services.AddIntegrationEventsPublisher();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
