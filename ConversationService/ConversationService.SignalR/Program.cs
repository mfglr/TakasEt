using ConversationService.Application;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Extentions;
using ConversationService.SignalR.Hubs;
using SharedLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSignalR();
builder.Services.AddServices();
builder.Services.AddJWT();
builder.Services.AddAppDbContext();
builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<ConversationHub>("Conversation");
app.Run();
