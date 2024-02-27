using SharedLibrary.Middlewares;
using UserService.Api.Extentions;
using UserService.Api.Filters;
using UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddAppDbContext();
builder.Services.AddJwt();
builder.Services.AddCustomCors();
builder.Services.AddScoped<UserNotFoundFilter>();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
