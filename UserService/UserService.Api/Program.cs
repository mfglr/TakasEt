using SharedLibrary.Middlewares;
using UserService.Api.Extentions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddAppDbContext();
builder.Services.AddJwt();
builder.Services.AddCustomCors();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseCors("local");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
