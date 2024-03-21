using Microsoft.EntityFrameworkCore;
using SharedLibrary.Middlewares;
using UserService.Api.Extentions;
using UserService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddApplication();
builder.Services.AddAppDbContext();
builder.Services.AddJwt();
builder.Services.AddCustomCors();
builder.Services.AddServices();

var app = builder.Build();

//migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}


// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseCors("local");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
