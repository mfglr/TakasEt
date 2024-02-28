using AuthService.Web.Extentions;
using SharedLibrary.Middlewares;

// Add services to the container.
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddCustomDbContext();
builder.Services.AddApplication();
builder.Services.AddCustomCors();
builder.Services.AddCustomIdentity();
builder.Services.AddThirdPartyAuhentication();
builder.Services.AddJWT();
builder.Services.AddServices();

var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("local");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();
