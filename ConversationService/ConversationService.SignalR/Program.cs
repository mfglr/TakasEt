using ConversationService.Application;
using ConversationService.Infrastructure;
using ConversationService.SignalR.Extentions;
using ConversationService.SignalR.Hubs;
using SharedLibrary;
using SharedLibrary.Middlewares;
using SharedLibrary.Services;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder
    .Services
    .AddSignalR()
    .AddJsonProtocol(
        c => c.PayloadSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
    );

builder.Services.AddScoped<UserAccountService>();
builder.Services.AddScoped<BlockingCheckerService>();

builder.Services.AddJWT();
builder.Services.AddHttpContextAccessor();
builder.Services.AddAppDbContext();
builder.Services.AddApplication();
builder.Services.AddIntegrationEventsPublisher();

var app = builder.Build();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapHub<ConversationHub>("Conversation");
app.Run();
