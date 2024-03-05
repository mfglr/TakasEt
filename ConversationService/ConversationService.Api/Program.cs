using ConversationService.Application;
using ConversationService.Infrastructure;
using ConversationService.Api.Extentions;
using ConversationService.Api.Hubs;
using SharedLibrary.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSignalR();
builder.Services.AddCustomCors();
builder.Services.AddServices();
builder.Services.AddJWT();
builder.Services.AddAppDbContext();
builder.Services.AddApplication();

var app = builder.Build();

app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseCors("local");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ConversationHub>("conversation");
app.Run();
