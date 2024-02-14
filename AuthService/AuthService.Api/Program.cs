using AuthService.Api.Extentions;
using SharedLibrary;
using SharedLibrary.Middlewares;
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

builder.Services.AddCustomDbContext();
builder.Services.AddCustomIdentity();
builder.Services.AddJWT();
builder.Services.AddCustomMediatR();
builder.Services.AddJsonSerializerSettingsForCustomExceptionMiddleware();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
