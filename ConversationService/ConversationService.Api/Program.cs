using ConversationService.Application;
using ConversationService.Infrastructure;
using ConversationService.Api.Extentions;
using SharedLibrary.Middlewares;
using ConversationService.Application.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCustomCors();
builder.Services.AddServices();
builder.Services.AddJWT();
builder.Services.AddAppDbContext();
builder.Services.AddApplication();

var app = builder.Build();

//migration
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("local");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<MessageHub>("message");
app.Run();
