using ConversationService.Api.Extentions;
using ConversationService.Api.HubFilters;
using ConversationService.Application;
using ConversationService.Application.Hubs;
using ConversationService.Infrastructure;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SharedLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR(opt => {
    opt.AddFilter<ExceptionHubFilter>();
    opt.AddFilter<SetHttpContextHubFilter>();
});
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
