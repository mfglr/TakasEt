using Microsoft.Extensions.Options;
using PhotoStockMicroservice.Api.Configurations;
using PhotoStockMicroservice.Api.Services.Abstracts;
using PhotoStockMicroservice.Api.Services.Concreate;
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
builder.Services.AddAppSharedLibrary();
builder.Services.AddScoped<IImageService,ImageService>();
builder.Services.AddScoped<IBlobService, LocalBlobService>();

builder.Services.Configure<ContainerSettings>(builder.Configuration.GetSection("ContainerSettings"));
builder.Services.AddSingleton<IContainerSettings>(
    sp => sp.GetRequiredService<IOptions<ContainerSettings>>().Value
);


var app = builder.Build();


// Configure the HTTP request pipeline.
app.UseMiddleware<CustomExceptionHandlerMiddleware>();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
